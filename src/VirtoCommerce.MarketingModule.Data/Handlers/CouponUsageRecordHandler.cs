using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.MarketingModule.Core.Model.Promotions;
using VirtoCommerce.MarketingModule.Core.Model.Promotions.Search;
using VirtoCommerce.MarketingModule.Core.Search;
using VirtoCommerce.MarketingModule.Core.Services;
using VirtoCommerce.OrdersModule.Core.Events;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Events;

namespace VirtoCommerce.MarketingModule.Data.Handlers
{


    /// <summary>
    /// Represents the logic of recording the use of coupons on both levels (Cart and Order).
    /// </summary>
    public class CouponUsageRecordHandler : IEventHandler<OrderChangedEvent>
    {
        private readonly IPromotionUsageService _usageService;
        private readonly IPromotionUsageSearchService _promotionUsageSearchService;

        public CouponUsageRecordHandler(IPromotionUsageService usageService, IPromotionUsageSearchService promotionUsageSearchService)
        {
            _usageService = usageService;
            _promotionUsageSearchService = promotionUsageSearchService;
            EqualityComparer = AnonymousComparer.Create((PromotionUsage x) => string.Join(":", x.PromotionId, x.CouponCode, x.ObjectId));
        }

        private IEqualityComparer<PromotionUsage> EqualityComparer { get; set; }

        #region Implementation of IHandler<in OrderChangedEvent>

        public virtual Task Handle(OrderChangedEvent message)
        {
            BackgroundJob.Enqueue(() => HandleCouponUsages(message));

            return Task.CompletedTask;
        }

        #endregion

        [DisableConcurrentExecution(60 * 60 * 24)]
        public virtual async Task HandleCouponUsages(OrderChangedEvent message)
        {
            foreach (var changedEntry in message.ChangedEntries)
            {
                if (changedEntry.EntryState == EntryState.Added)
                {
                    var oldUsages = new List<PromotionUsage>();
                    var newUsages = GetCouponUsages(changedEntry.NewEntry.Id, changedEntry.NewEntry, changedEntry.NewEntry.CustomerId, changedEntry.NewEntry.CustomerName);
                    await RecordUsages(changedEntry.NewEntry.Id, oldUsages, newUsages);
                }
            }
        }

        private async Task RecordUsages(string objectId, IEnumerable<PromotionUsage> oldUsages, IEnumerable<PromotionUsage> newUsages)
        {
            var toAddUsages = newUsages.Except(oldUsages, EqualityComparer);
            var toRemoveUsages = oldUsages.Except(newUsages, EqualityComparer);
            if (!toAddUsages.IsNullOrEmpty())
            {
                await _usageService.SaveUsagesAsync(toAddUsages.ToArray());
            }
            if (!toRemoveUsages.IsNullOrEmpty())
            {
                var alreadyExistUsages = (await _promotionUsageSearchService.SearchUsagesAsync(new PromotionUsageSearchCriteria { ObjectId = objectId })).Results;
                await _usageService.DeleteUsagesAsync(alreadyExistUsages.Intersect(toRemoveUsages, EqualityComparer).Select(x => x.Id).ToArray());
            }
        }

        private List<PromotionUsage> GetCouponUsages(string objectId, IHasDiscounts hasDiscounts, string customerId, string customerName)
        {
            var usageComparer = AnonymousComparer.Create((PromotionUsage x) => string.Join(":", x.PromotionId, x.CouponCode, x.ObjectId));
            var result = hasDiscounts.GetFlatObjectsListWithInterface<IHasDiscounts>()
                .Where(x => x.Discounts != null)
                .SelectMany(x => x.Discounts)
                .Where(x => !string.IsNullOrEmpty(x.Coupon))
                .Select(x => new PromotionUsage
                {
                    CouponCode = x.Coupon,
                    PromotionId = x.PromotionId,
                    ObjectId = objectId,
                    ObjectType = hasDiscounts.GetType().Name,
                    UserId = customerId,
                    UserName = customerName
                })
                .Distinct(usageComparer)
                .ToList();

            return result;
        }
    }
}

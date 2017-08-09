﻿using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Common;
using VirtoCommerce.Domain.Marketing.Model;
using VirtoCommerce.DynamicExpressionsModule.Data.Promotion;
using VirtoCommerce.MarketingModule.Data.Promotions;
using Xunit;

namespace VirtoCommerce.MarketingModule.Test.DynamicPromotionEvaluations.BlockCatalogCondition
{
    public class ConditionCurrencyIsTests : EvaluationBase
    {
        [Theory]
        [MemberData(nameof(TestConditionDataGenerator.GetConditions), MemberType = typeof(TestConditionDataGenerator))]
        public void CheckPromotionValid(IConditionExpression[] conditions, IRewardExpression[] rewards, IEvaluationContext context, EvaluationResult evaluationResult)
        {
            DynamicPromotion dynamicPromotion = GetDynamicPromotion(conditions, rewards);

            var result = dynamicPromotion.EvaluatePromotion(context);

            Assert.Equal(evaluationResult.ValidCount, result.Count(r => r.IsValid));
            Assert.Equal(evaluationResult.InvalidCount, result.Count(r => !r.IsValid));
        }

        public class TestConditionDataGenerator
        {
            private static string Currency1 = "USD";
            private static string Currency2 = "EUR";

            public static IEnumerable<object[]> GetConditions()
            {
                yield return new object[]
                {
                    new IConditionExpression[] { new ConditionCurrencyIs { Currency = Currency1 } },
                    new IRewardExpression[] { new RewardItemGetOfRel() },
                    context,
                    new EvaluationResult
                    {
                        ValidCount = 3,
                        InvalidCount = 0
                    }
                };

                yield return new object[]
                {
                    new IConditionExpression[] { new ConditionCurrencyIs { Currency = Currency2 } },
                    new IRewardExpression[] { new RewardItemGetOfRel() },
                    context,
                    new EvaluationResult
                    {
                        ValidCount = 0,
                        InvalidCount = 3
                    }
                };
            }

            private static IEvaluationContext context = new PromotionEvaluationContext
            {
                Currency = Currency1,
                PromoEntries = new List<ProductPromoEntry>
                {
                    new ProductPromoEntry(),
                    new ProductPromoEntry(),
                    new ProductPromoEntry()
                }
            };
        }
    }
}

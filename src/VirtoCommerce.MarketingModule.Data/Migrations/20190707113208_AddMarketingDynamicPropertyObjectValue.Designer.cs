// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VirtoCommerce.MarketingModule.Data.Repositories;

namespace VirtoCommerce.MarketingModule.Data.Migrations
{
    [DbContext(typeof(MarketingDbContext))]
    [Migration("20190707113208_AddMarketingDynamicPropertyObjectValue")]
    partial class AddMarketingDynamicPropertyObjectValue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.CouponEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Code")
                        .HasMaxLength(64);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<int>("MaxUsesNumber");

                    b.Property<int>("MaxUsesPerUser");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("OuterId")
                        .HasMaxLength(128);

                    b.Property<string>("PromotionId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.HasIndex("Code", "PromotionId")
                        .IsUnique()
                        .HasName("IX_CodeAndPromotionId")
                        .HasFilter("[Code] IS NOT NULL");

                    b.ToTable("Coupon");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentFolderEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2048);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ParentFolderId");

                    b.HasKey("Id");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("DynamicContentFolder");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentItemDynamicPropertyObjectValueEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<bool?>("BooleanValue");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DateTimeValue");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("decimal(18,5)");

                    b.Property<string>("DictionaryItemId")
                        .HasMaxLength(128);

                    b.Property<int?>("IntegerValue");

                    b.Property<string>("Locale")
                        .HasMaxLength(64);

                    b.Property<string>("LongTextValue");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ObjectId")
                        .HasMaxLength(128);

                    b.Property<string>("ObjectType")
                        .HasMaxLength(256);

                    b.Property<string>("PropertyId")
                        .HasMaxLength(128);

                    b.Property<string>("PropertyName")
                        .HasMaxLength(256);

                    b.Property<string>("ShortTextValue")
                        .HasMaxLength(512);

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.HasIndex("ObjectType", "ObjectId")
                        .HasName("IX_ObjectType_ObjectId");

                    b.ToTable("DynamicContentItemDynamicPropertyObjectValue");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentItemEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("ContentTypeId")
                        .HasMaxLength(64);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<string>("FolderId");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2048);

                    b.Property<bool>("IsMultilingual");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("DynamicContentItem");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentPlaceEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<string>("FolderId");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2048);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("DynamicContentPlace");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentPublishingGroupEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("ConditionExpression");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("OuterId")
                        .HasMaxLength(128);

                    b.Property<string>("PredicateVisualTreeSerialized");

                    b.Property<int>("Priority");

                    b.Property<DateTime?>("StartDate");

                    b.Property<string>("StoreId")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("DynamicContentPublishingGroup");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PromotionEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CatalogId")
                        .HasMaxLength(128);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAllowCombiningWithSelf");

                    b.Property<bool>("IsExclusive");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("OuterId")
                        .HasMaxLength(128);

                    b.Property<int>("PerCustomerLimit");

                    b.Property<string>("PredicateSerialized");

                    b.Property<string>("PredicateVisualTreeSerialized");

                    b.Property<int>("Priority");

                    b.Property<string>("RewardsSerialized");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("StoreId")
                        .HasMaxLength(128);

                    b.Property<int>("TotalLimit");

                    b.HasKey("Id");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PromotionStoreEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("PromotionId")
                        .IsRequired();

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.HasIndex("StoreId");

                    b.ToTable("PromotionStore");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PromotionUsageEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CouponCode")
                        .HasMaxLength(64);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ObjectId")
                        .HasMaxLength(128);

                    b.Property<string>("ObjectType")
                        .HasMaxLength(128);

                    b.Property<string>("PromotionId")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.Property<string>("UserName")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionUsage");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PublishingGroupContentItemEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DynamicContentItemId");

                    b.Property<string>("DynamicContentPublishingGroupId")
                        .IsRequired();

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("DynamicContentItemId");

                    b.HasIndex("DynamicContentPublishingGroupId");

                    b.ToTable("PublishingGroupContentItem");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PublishingGroupContentPlaceEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DynamicContentPlaceId")
                        .IsRequired();

                    b.Property<string>("DynamicContentPublishingGroupId")
                        .IsRequired();

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("DynamicContentPlaceId");

                    b.HasIndex("DynamicContentPublishingGroupId");

                    b.ToTable("PublishingGroupContentPlace");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.CouponEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.PromotionEntity", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentFolderEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.DynamicContentFolderEntity", "ParentFolder")
                        .WithMany()
                        .HasForeignKey("ParentFolderId");
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentItemDynamicPropertyObjectValueEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.DynamicContentItemEntity", "DynamicContentItem")
                        .WithMany("DynamicPropertyObjectValues")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentItemEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.DynamicContentFolderEntity", "Folder")
                        .WithMany("ContentItems")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.DynamicContentPlaceEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.DynamicContentFolderEntity", "Folder")
                        .WithMany("ContentPlaces")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PromotionStoreEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.PromotionEntity", "Promotion")
                        .WithMany("Stores")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PromotionUsageEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.PromotionEntity", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PublishingGroupContentItemEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.DynamicContentItemEntity", "ContentItem")
                        .WithMany()
                        .HasForeignKey("DynamicContentItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.DynamicContentPublishingGroupEntity", "PublishingGroup")
                        .WithMany("ContentItems")
                        .HasForeignKey("DynamicContentPublishingGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VirtoCommerce.MarketingModule.Data.Model.PublishingGroupContentPlaceEntity", b =>
                {
                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.DynamicContentPlaceEntity", "ContentPlace")
                        .WithMany()
                        .HasForeignKey("DynamicContentPlaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VirtoCommerce.MarketingModule.Data.Model.DynamicContentPublishingGroupEntity", "PublishingGroup")
                        .WithMany("ContentPlaces")
                        .HasForeignKey("DynamicContentPublishingGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

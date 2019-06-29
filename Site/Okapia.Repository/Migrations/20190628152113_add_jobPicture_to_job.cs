using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Okapia.Repository.Migrations
{
    public partial class add_jobPicture_to_job : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.CreateSequence<int>(
                name: "JobSeq",
                schema: "shared");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatgoryName = table.Column<string>(maxLength: 400, nullable: true),
                    CategorySmallDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    CategoryMetaTag = table.Column<string>(maxLength: 200, nullable: true),
                    CategoryMetaDesccription = table.Column<string>(maxLength: 200, nullable: true),
                    CategorySEOHead = table.Column<string>(maxLength: 400, nullable: true),
                    CategoryPageTittle = table.Column<string>(maxLength: 400, nullable: true),
                    CategoryThumbPicURL = table.Column<string>(maxLength: 1000, nullable: true),
                    JobLinkTitle = table.Column<string>(maxLength: 100, nullable: true),
                    CategoryParentID = table.Column<int>(nullable: false),
                    Job = table.Column<string>(maxLength: 10, nullable: true),
                    RegisteringEmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false),
                    GroupDescription = table.Column<string>(maxLength: 500, nullable: true),
                    GroupCreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobName = table.Column<string>(maxLength: 200, nullable: false),
                    JobSmallDescription = table.Column<string>(maxLength: 2000, nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    JobContactTitile = table.Column<string>(maxLength: 400, nullable: true),
                    JobManagerFirstName = table.Column<string>(maxLength: 60, nullable: true),
                    JobManagerLastName = table.Column<string>(maxLength: 60, nullable: true),
                    JobEmailAddress = table.Column<string>(maxLength: 200, nullable: true),
                    JobCategory = table.Column<int>(nullable: false),
                    JobTel1 = table.Column<string>(maxLength: 20, nullable: true),
                    JobTel2 = table.Column<string>(maxLength: 20, nullable: true),
                    JobMobile1 = table.Column<string>(maxLength: 20, nullable: true),
                    JobMobile2 = table.Column<string>(maxLength: 50, nullable: true),
                    JobGeoLocation = table.Column<string>(nullable: true),
                    JobProvienceID = table.Column<int>(nullable: false),
                    JobCityID = table.Column<int>(nullable: false),
                    JobAddress = table.Column<string>(maxLength: 1000, nullable: true),
                    JobMap = table.Column<string>(maxLength: 1000, nullable: true),
                    JobPageTittle = table.Column<string>(maxLength: 400, nullable: true),
                    JobSlug = table.Column<string>(maxLength: 200, nullable: false),
                    JobMetaTag = table.Column<string>(maxLength: 200, nullable: true),
                    JobMetaDesccription = table.Column<string>(maxLength: 200, nullable: true),
                    JobSEOHead = table.Column<string>(maxLength: 400, nullable: true),
                    JobCanonicalAddress = table.Column<string>(maxLength: 300, nullable: true),
                    JobContractNumber = table.Column<string>(maxLength: 10, nullable: true),
                    JobBenefitPercentForEndCustomer = table.Column<double>(nullable: true),
                    JobBenefitPercentForCompany = table.Column<double>(nullable: true),
                    JobRemoved301InsteadURL = table.Column<string>(maxLength: 200, nullable: true),
                    JobDiscountPercentForCustomer = table.Column<double>(nullable: true),
                    JobDiscountPercentForCompnay = table.Column<double>(nullable: true),
                    JobDiscountPercentForSabaMehrDiscount = table.Column<double>(nullable: true),
                    JobBefitPercentForIntroducingEndCustomer = table.Column<double>(nullable: true),
                    MarketerPercentForRegisteringShop = table.Column<double>(nullable: true),
                    MarketerID = table.Column<int>(nullable: true),
                    JobPosNameNumber = table.Column<string>(maxLength: 400, nullable: true),
                    JobAccountNumber = table.Column<string>(maxLength: 400, nullable: true),
                    JobShowOrderIncategory = table.Column<int>(nullable: true),
                    ShowInHomePage = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RegisteringEmployerID = table.Column<int>(nullable: true),
                    CustomerIntroductionLimit = table.Column<int>(nullable: false),
                    IsWebsite = table.Column<bool>(nullable: true),
                    WebSiteUrl = table.Column<string>(maxLength: 200, nullable: true),
                    InstagramUrl = table.Column<string>(maxLength: 200, nullable: true),
                    TelegramUrl = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "JobRelations",
                columns: table => new
                {
                    JobRelationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobID = table.Column<int>(nullable: false),
                    RelatedID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRelations", x => x.JobRelationID);
                });

            migrationBuilder.CreateTable(
                name: "JobTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ammount = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    PanTrunc = table.Column<string>(maxLength: 16, nullable: false),
                    RRN = table.Column<long>(nullable: false),
                    LocalDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrAmmount = table.Column<decimal>(type: "decimal(18, 3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageCategory",
                columns: table => new
                {
                    PageCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageCategoryName = table.Column<string>(maxLength: 50, nullable: true),
                    PageCategorySmallPictutre = table.Column<string>(maxLength: 400, nullable: true),
                    PageCategorySmallPictutreAlt = table.Column<string>(maxLength: 400, nullable: true),
                    PageCategoryPageTittle = table.Column<string>(maxLength: 400, nullable: true),
                    PageCategorySlug = table.Column<string>(maxLength: 200, nullable: true),
                    PageCategoryMetaTag = table.Column<string>(maxLength: 200, nullable: true),
                    PageCategoryMetaDesccription = table.Column<string>(maxLength: 200, nullable: true),
                    PageCategorySEOHead = table.Column<string>(maxLength: 400, nullable: true),
                    PageCanonicalAddress = table.Column<string>(maxLength: 300, nullable: true),
                    PageCategoryIsDeleted = table.Column<bool>(nullable: true),
                    PageCategoryRemoved301InsteadURL = table.Column<string>(maxLength: 200, nullable: true),
                    PageCategoryParentID = table.Column<int>(nullable: true),
                    PageCategoryLinkToolTip = table.Column<string>(maxLength: 100, nullable: true),
                    PageCategoryShowOrder = table.Column<int>(nullable: true),
                    PageCategoryRegisteredByEmployeId = table.Column<int>(nullable: false),
                    PageCategoryRegisterDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageCategory", x => x.PageCategoryID);
                    table.ForeignKey(
                        name: "FK_PageCategory_PageCategory",
                        column: x => x.PageCategoryParentID,
                        principalTable: "PageCategory",
                        principalColumn: "PageCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Province = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserFirstName = table.Column<string>(maxLength: 200, nullable: false),
                    UserLastName = table.Column<string>(maxLength: 200, nullable: false),
                    UserNationalCode = table.Column<string>(maxLength: 10, nullable: false),
                    UserPhoneNumber = table.Column<string>(maxLength: 13, nullable: false),
                    UserProvince = table.Column<int>(nullable: false),
                    UserCity = table.Column<int>(nullable: false),
                    UserAddress = table.Column<string>(maxLength: 500, nullable: true),
                    UserPostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    UserEmail = table.Column<string>(maxLength: 50, nullable: true),
                    UserBirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserCustomerIntroductionLimit = table.Column<int>(nullable: false),
                    UserRegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserIsActivated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Modal",
                columns: table => new
                {
                    ModalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModalTtitle = table.Column<string>(maxLength: 100, nullable: false),
                    ModalMessage = table.Column<string>(maxLength: 500, nullable: false),
                    ModalPageLink = table.Column<string>(maxLength: 1000, nullable: true),
                    ModalPic = table.Column<string>(maxLength: 50, nullable: true),
                    ModalGroupId = table.Column<int>(nullable: false),
                    ModalCreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModalStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModalEndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modal", x => x.ModalId);
                    table.ForeignKey(
                        name: "FK_Modals_Groups",
                        column: x => x.ModalGroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobPictures",
                columns: table => new
                {
                    JobPictureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobPictureTitle = table.Column<string>(maxLength: 100, nullable: true),
                    JobPictureSmallDescription = table.Column<string>(maxLength: 400, nullable: true),
                    JobPictureAlt = table.Column<string>(maxLength: 50, nullable: true),
                    JobPicturThumbURL = table.Column<string>(maxLength: 400, nullable: true),
                    JobPictureURL = table.Column<string>(maxLength: 400, nullable: true),
                    JobPictureSortOrder = table.Column<int>(nullable: true),
                    JobID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPictures", x => x.JobPictureID);
                    table.ForeignKey(
                        name: "FK_JobPicture_Jobs",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    PageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageCategoryID = table.Column<int>(nullable: false),
                    PageTittle = table.Column<string>(maxLength: 400, nullable: false),
                    PageSlug = table.Column<string>(maxLength: 200, nullable: false),
                    PageMetaTag = table.Column<string>(maxLength: 200, nullable: true),
                    PageMetaDesccription = table.Column<string>(maxLength: 200, nullable: true),
                    PageSEOHead = table.Column<string>(maxLength: 400, nullable: true),
                    PageCanonicalAddress = table.Column<string>(maxLength: 300, nullable: true),
                    PageIsDeleted = table.Column<bool>(nullable: true),
                    PageRemoved301InsteadURL = table.Column<string>(maxLength: 200, nullable: true),
                    PageSmallDescription = table.Column<string>(maxLength: 2000, nullable: true),
                    PageContent = table.Column<string>(nullable: true),
                    PageRegisteringEmployeeID = table.Column<int>(nullable: false),
                    PageRegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.PageID);
                    table.ForeignKey(
                        name: "FK_Page_PageCategory",
                        column: x => x.PageCategoryID,
                        principalTable: "PageCategory",
                        principalColumn: "PageCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ProvinceID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_Province",
                        column: x => x.ProvinceID,
                        principalTable: "Province",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageComments",
                columns: table => new
                {
                    PageCommentID = table.Column<int>(nullable: false),
                    PageID = table.Column<int>(nullable: false),
                    CommentUserID = table.Column<int>(nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CommentTitle = table.Column<string>(maxLength: 200, nullable: true),
                    CommnetText = table.Column<string>(maxLength: 4000, nullable: true),
                    IsConfirmedByAdminiStrator = table.Column<bool>(nullable: true),
                    CommentAgrreCount = table.Column<int>(nullable: false),
                    CommentDisAgreeCount = table.Column<int>(nullable: false),
                    CommentPageURL = table.Column<string>(maxLength: 200, nullable: true),
                    PageCommentConfiringUserID = table.Column<int>(nullable: true),
                    PageCommentConfirmDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageComments", x => x.PageCommentID);
                    table.ForeignKey(
                        name: "FK_PageComments_Page",
                        column: x => x.PageID,
                        principalTable: "Page",
                        principalColumn: "PageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighborhood_District",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceID",
                table: "City",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_District_CityId",
                table: "District",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPictures_JobID",
                table: "JobPictures",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Modal_ModalGroupId",
                table: "Modal",
                column: "ModalGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_DistrictId",
                table: "Neighborhood",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_PageCategoryID",
                table: "Page",
                column: "PageCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PageCategory_PageCategoryParentID",
                table: "PageCategory",
                column: "PageCategoryParentID");

            migrationBuilder.CreateIndex(
                name: "IX_PageComments_PageID",
                table: "PageComments",
                column: "PageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "JobPictures");

            migrationBuilder.DropTable(
                name: "JobRelations");

            migrationBuilder.DropTable(
                name: "JobTransactions");

            migrationBuilder.DropTable(
                name: "Modal");

            migrationBuilder.DropTable(
                name: "Neighborhood");

            migrationBuilder.DropTable(
                name: "PageComments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "PageCategory");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropSequence(
                name: "JobSeq",
                schema: "shared");
        }
    }
}

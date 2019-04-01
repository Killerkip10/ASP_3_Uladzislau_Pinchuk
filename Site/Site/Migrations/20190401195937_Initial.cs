using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Site.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZodiacSigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZodiacSigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Width = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    CountChildren = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    ZodiacSignId = table.Column<int>(nullable: false),
                    NationalityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_ZodiacSigns_ZodiacSignId",
                        column: x => x.ZodiacSignId,
                        principalTable: "ZodiacSigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAdditional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CustomerId = table.Column<int>(nullable: false),
                    AdditionalServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdditional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAdditional_AdditionalServices_AdditionalServiceId",
                        column: x => x.AdditionalServiceId,
                        principalTable: "AdditionalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAdditional_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdditionalServices",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Gold", "Ring", 120.0 },
                    { 2, "Milota", "Angels", 9999.0 }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "Id", "Name", "Remarks" },
                values: new object[,]
                {
                    { 1, "Belarus", "cool people" },
                    { 2, "Russian", "countrymate" },
                    { 3, "Pole", "also countrymate" }
                });

            migrationBuilder.InsertData(
                table: "ZodiacSigns",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "very stubborn", "Ram" },
                    { 2, "wet", "Aquarius" },
                    { 3, "dangerous", "Scorpio" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adress", "Birthday", "CountChildren", "FullName", "Gender", "Job", "NationalityId", "Passport", "Phone", "Weight", "Width", "ZodiacSignId" },
                values: new object[] { 1, "gomel", new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tom Anderson", "man", "Cleaner", 1, "HB2721659", "+375298645383", 100f, 100f, 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adress", "Birthday", "CountChildren", "FullName", "Gender", "Job", "NationalityId", "Passport", "Phone", "Weight", "Width", "ZodiacSignId" },
                values: new object[] { 2, "gomel", new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), 0, "Vlad Pinchuk", "man", "Programmer", 1, "HB27324329", "+37526702656", 90f, 190f, 2 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adress", "Birthday", "CountChildren", "FullName", "Gender", "Job", "NationalityId", "Passport", "Phone", "Weight", "Width", "ZodiacSignId" },
                values: new object[] { 3, "gomel", new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), 20, "Pavel Stelmah", "man", "Front end developer", 3, "HB2722349", "+375292343483", 80f, 100f, 3 });

            migrationBuilder.InsertData(
                table: "CustomerAdditional",
                columns: new[] { "Id", "AdditionalServiceId", "CustomerId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "CustomerAdditional",
                columns: new[] { "Id", "AdditionalServiceId", "CustomerId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "CustomerAdditional",
                columns: new[] { "Id", "AdditionalServiceId", "CustomerId" },
                values: new object[] { 3, 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdditional_AdditionalServiceId",
                table: "CustomerAdditional",
                column: "AdditionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdditional_CustomerId",
                table: "CustomerAdditional",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NationalityId",
                table: "Customers",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ZodiacSignId",
                table: "Customers",
                column: "ZodiacSignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAdditional");

            migrationBuilder.DropTable(
                name: "AdditionalServices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "ZodiacSigns");
        }
    }
}

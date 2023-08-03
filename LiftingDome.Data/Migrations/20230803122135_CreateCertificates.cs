using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftingDome.Data.Migrations
{
    public partial class CreateCertificates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0ac8c807-8d8b-47d3-9d70-1852b5c1b8e3"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0e5cde5f-e7e9-44a7-9e4a-61dc1fe7b2ec"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("1ab004f1-27f9-4f86-842e-08fb782212ef"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("c4f56838-a988-45ff-b782-0acffed3b15b"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("cc7336cf-0014-4cfc-ae1f-94f76701b4dd"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("ea902156-8f9b-4502-94e2-c0de276692c4"));

            migrationBuilder.AddColumn<string>(
                name: "CertificateName",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CoachCertificateId",
                table: "Coaches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15e4991a-a538-4618-b021-d1ef2303432d"), "NFPT" },
                    { new Guid("221ae88d-54c0-4d6a-b2d6-7243e96c959a"), "ACSM" },
                    { new Guid("397d36b2-2b51-4ea6-bf6c-f94222790fb1"), "ACE" },
                    { new Guid("3be14074-a35b-49fb-b1ac-1dc78182b0fe"), "NSCA" },
                    { new Guid("51ec24ab-8bb6-4911-808c-471a4482bb08"), "ISSA" },
                    { new Guid("6f95564c-c4ad-4d53-9693-5dd2e6469d51"), "NASM" },
                    { new Guid("c76e6500-5846-49fd-a2f2-ccbcdc31ff3c"), "AFPA" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "HasBeenEdited", "TaggedUser", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("003a112f-26ef-40ba-8c7a-d1218bd66998"), 4, false, null, "Welcome to The Lifting Dome! The No.1 place for fitness and health! Feel free to browse through the published workouts and try some out, or become a coach yourself and create new workouts!", new Guid("d659b40a-2c01-417f-a452-19b194b2c081") },
                    { new Guid("a74fdb0d-8ff8-482e-9521-ca73a0b31b2c"), 1, false, null, "Hi! I don't understand how to do the 5/3/1 workout. Can a coach instruct me how to do it?", new Guid("199850bc-ea29-43b0-b342-a11a7fc6cc8c") }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "Description", "HasBeenEdited", "ImageURL", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("1244565a-dc96-4c52-8f07-63d8b0e86815"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", false, "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("91e5ba73-30fb-4ea0-93b7-b52248e3b449"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", false, "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("bac019e4-ba47-46c7-a528-73445403ab6f"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 },
                    { new Guid("ffa58c56-0af8-4c9d-86f9-506e7eafdece"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "The best way for beginner and intermediate strength athletes to build strength.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CoachCertificateId",
                table: "Coaches",
                column: "CoachCertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Certificates_CoachCertificateId",
                table: "Coaches",
                column: "CoachCertificateId",
                principalTable: "Certificates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Certificates_CoachCertificateId",
                table: "Coaches");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_CoachCertificateId",
                table: "Coaches");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("003a112f-26ef-40ba-8c7a-d1218bd66998"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a74fdb0d-8ff8-482e-9521-ca73a0b31b2c"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("1244565a-dc96-4c52-8f07-63d8b0e86815"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("91e5ba73-30fb-4ea0-93b7-b52248e3b449"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("bac019e4-ba47-46c7-a528-73445403ab6f"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("ffa58c56-0af8-4c9d-86f9-506e7eafdece"));

            migrationBuilder.DropColumn(
                name: "CertificateName",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "CoachCertificateId",
                table: "Coaches");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "HasBeenEdited", "IsActive", "TaggedUser", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ac8c807-8d8b-47d3-9d70-1852b5c1b8e3"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Hi! I don't understand how to do the 5/3/1 workout. Can a coach instruct me how to do it?", new Guid("199850bc-ea29-43b0-b342-a11a7fc6cc8c") },
                    { new Guid("0e5cde5f-e7e9-44a7-9e4a-61dc1fe7b2ec"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Welcome to The Lifting Dome! The No.1 place for fitness and health! Feel free to browse through the published workouts and try some out, or become a coach yourself and create new workouts!", new Guid("d659b40a-2c01-417f-a452-19b194b2c081") }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "CreatedOn", "Description", "HasBeenEdited", "ImageURL", "IsActive", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("1ab004f1-27f9-4f86-842e-08fb782212ef"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", false, "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", false, 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("c4f56838-a988-45ff-b782-0acffed3b15b"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", false, 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 },
                    { new Guid("cc7336cf-0014-4cfc-ae1f-94f76701b4dd"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", false, "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", false, 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("ea902156-8f9b-4502-94e2-c0de276692c4"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The best way for beginner and intermediate strength athletes to build strength.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", false, 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftingDome.Data.Migrations
{
    public partial class RemoveCoachCertificateIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Certificates_CoachCertificateId",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_CoachCertificateId",
                table: "Coaches");

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("15e4991a-a538-4618-b021-d1ef2303432d"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("221ae88d-54c0-4d6a-b2d6-7243e96c959a"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("397d36b2-2b51-4ea6-bf6c-f94222790fb1"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("3be14074-a35b-49fb-b1ac-1dc78182b0fe"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("51ec24ab-8bb6-4911-808c-471a4482bb08"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("6f95564c-c4ad-4d53-9693-5dd2e6469d51"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("c76e6500-5846-49fd-a2f2-ccbcdc31ff3c"));

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
                name: "CoachCertificateId",
                table: "Coaches");

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("07d1eda8-4927-459a-be2b-7c16cd3919f1"), "NFPT" },
                    { new Guid("143ebd0d-7dae-4016-99f1-94d88525c735"), "ACE" },
                    { new Guid("26684226-2b68-4eb9-a909-c2356f6e34d7"), "NASM" },
                    { new Guid("376d99cd-89f1-490e-8f11-c5e51c398e2c"), "ISSA" },
                    { new Guid("4fd89714-4c02-4eba-85b8-0d30a38f52a0"), "ACSM" },
                    { new Guid("58ca74da-7ace-44ca-addc-c616f0d15fbb"), "AFPA" },
                    { new Guid("5c4d7cbc-b20c-4121-ac82-fffedb8a1a3f"), "NSCA" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "HasBeenEdited", "TaggedUser", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("3e871a54-f37a-48dc-be7f-d314a0a38e65"), 1, false, null, "Hi! I don't understand how to do the 5/3/1 workout. Can a coach instruct me how to do it?", new Guid("199850bc-ea29-43b0-b342-a11a7fc6cc8c") },
                    { new Guid("48dee13a-8ebd-456c-b44a-4721b595d99a"), 4, false, null, "Welcome to The Lifting Dome! The No.1 place for fitness and health! Feel free to browse through the published workouts and try some out, or become a coach yourself and create new workouts!", new Guid("d659b40a-2c01-417f-a452-19b194b2c081") }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "Description", "HasBeenEdited", "ImageURL", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("4adf7af1-6e30-4569-b773-19245b4b0ed8"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "The best way for beginner and intermediate strength athletes to build strength.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 },
                    { new Guid("4e631966-28ee-46a2-812e-5536800f88c9"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", false, "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("ab84f375-4f40-486c-98ad-3ba624681b5b"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 },
                    { new Guid("bf0394a3-6009-4a53-9491-c66d7a110aea"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", false, "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("07d1eda8-4927-459a-be2b-7c16cd3919f1"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("143ebd0d-7dae-4016-99f1-94d88525c735"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("26684226-2b68-4eb9-a909-c2356f6e34d7"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("376d99cd-89f1-490e-8f11-c5e51c398e2c"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("4fd89714-4c02-4eba-85b8-0d30a38f52a0"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("58ca74da-7ace-44ca-addc-c616f0d15fbb"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("5c4d7cbc-b20c-4121-ac82-fffedb8a1a3f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e871a54-f37a-48dc-be7f-d314a0a38e65"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("48dee13a-8ebd-456c-b44a-4721b595d99a"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("4adf7af1-6e30-4569-b773-19245b4b0ed8"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("4e631966-28ee-46a2-812e-5536800f88c9"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("ab84f375-4f40-486c-98ad-3ba624681b5b"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("bf0394a3-6009-4a53-9491-c66d7a110aea"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoachCertificateId",
                table: "Coaches",
                type: "uniqueidentifier",
                nullable: true);

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
                columns: new[] { "Id", "CategoryId", "CreatedOn", "HasBeenEdited", "IsActive", "TaggedUser", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("003a112f-26ef-40ba-8c7a-d1218bd66998"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Welcome to The Lifting Dome! The No.1 place for fitness and health! Feel free to browse through the published workouts and try some out, or become a coach yourself and create new workouts!", new Guid("d659b40a-2c01-417f-a452-19b194b2c081") },
                    { new Guid("a74fdb0d-8ff8-482e-9521-ca73a0b31b2c"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Hi! I don't understand how to do the 5/3/1 workout. Can a coach instruct me how to do it?", new Guid("199850bc-ea29-43b0-b342-a11a7fc6cc8c") }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "CreatedOn", "Description", "HasBeenEdited", "ImageURL", "IsActive", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("1244565a-dc96-4c52-8f07-63d8b0e86815"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", false, "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", false, 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("91e5ba73-30fb-4ea0-93b7-b52248e3b449"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", false, "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", false, 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("bac019e4-ba47-46c7-a528-73445403ab6f"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", false, 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 },
                    { new Guid("ffa58c56-0af8-4c9d-86f9-506e7eafdece"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The best way for beginner and intermediate strength athletes to build strength.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", false, 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 }
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
    }
}

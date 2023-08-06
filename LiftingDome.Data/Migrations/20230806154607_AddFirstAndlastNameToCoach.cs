using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftingDome.Data.Migrations
{
    public partial class AddFirstAndlastNameToCoach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("102bf116-4f56-4163-8e62-a8d4f414da5d"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("60f092ac-a21b-49ba-9cf7-a5c3bf0432fe"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("710ff618-6fbd-4840-98a2-231deb806586"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("b3e72daa-f253-4895-a9fb-7bd2292a64bc"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("b76dc387-2070-4f90-a020-f9412f639454"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("d1552a77-25de-4e61-b4ff-4d2ce1235876"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("f36d1c84-bd0d-43e4-8890-ed26c97faabb"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0885b928-7821-45c2-bd56-b41333d0b0fe"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8d80c086-2354-4d24-b02d-507d76f61e8f"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("5351299a-69a6-43f1-940c-63a995d5ed93"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("671c58c5-8d56-42f8-8f49-6cc44f745df3"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("c6004b2d-2c20-45d9-9562-93bc6e0de18a"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("d60fcc11-6d56-4e40-8ed9-2c9aa6763d17"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("219ddea3-57c0-4e39-9eda-183602d09a0f"), "NASM" },
                    { new Guid("296fe26c-b072-4520-8ce6-0a398342c79f"), "ISSA" },
                    { new Guid("3606cfd7-f7bd-4d9f-9ddf-b67a0db4ec96"), "AFPA" },
                    { new Guid("4a7dbddb-ca25-403e-80f2-3e3a2e6bb4a9"), "NSCA" },
                    { new Guid("5124d4ec-8e86-4ca1-974a-b9555d3e54a5"), "NFPT" },
                    { new Guid("54d7b2cd-e4b3-4c4c-a7ce-57a3ef7067fe"), "ACE" },
                    { new Guid("8cab39c3-c4bc-495e-a3f1-467a094dea55"), "ACSM" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "HasBeenEdited", "TaggedUser", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("43dcd10c-0f50-475b-bef8-10590108baf7"), 1, false, null, "Hi! I don't understand how to do the 5/3/1 workout. Can a coach instruct me how to do it?", new Guid("199850bc-ea29-43b0-b342-a11a7fc6cc8c") },
                    { new Guid("a9adcb6a-7299-4e17-8324-c1ef8c2c3010"), 4, false, null, "Welcome to The Lifting Dome! The No.1 place for fitness and health! Feel free to browse through the published workouts and try some out, or become a coach yourself and create new workouts!", new Guid("d659b40a-2c01-417f-a452-19b194b2c081") }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "Description", "HasBeenEdited", "ImageURL", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("80a424e5-3b7c-424c-8dad-94752cbd8019"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", false, "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("91fe8788-53dd-492b-9b26-48781c6833f9"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", false, "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("aa2d3030-f755-4780-b9fa-09050a864197"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "The best way for beginner and intermediate strength athletes to build strength.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 },
                    { new Guid("fc413a20-3b81-495b-a658-590189ffc2ff"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("219ddea3-57c0-4e39-9eda-183602d09a0f"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("296fe26c-b072-4520-8ce6-0a398342c79f"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("3606cfd7-f7bd-4d9f-9ddf-b67a0db4ec96"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("4a7dbddb-ca25-403e-80f2-3e3a2e6bb4a9"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("5124d4ec-8e86-4ca1-974a-b9555d3e54a5"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("54d7b2cd-e4b3-4c4c-a7ce-57a3ef7067fe"));

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: new Guid("8cab39c3-c4bc-495e-a3f1-467a094dea55"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("43dcd10c-0f50-475b-bef8-10590108baf7"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a9adcb6a-7299-4e17-8324-c1ef8c2c3010"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("80a424e5-3b7c-424c-8dad-94752cbd8019"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("91fe8788-53dd-492b-9b26-48781c6833f9"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("aa2d3030-f755-4780-b9fa-09050a864197"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("fc413a20-3b81-495b-a658-590189ffc2ff"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Coaches");

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("102bf116-4f56-4163-8e62-a8d4f414da5d"), "NFPT" },
                    { new Guid("60f092ac-a21b-49ba-9cf7-a5c3bf0432fe"), "AFPA" },
                    { new Guid("710ff618-6fbd-4840-98a2-231deb806586"), "NSCA" },
                    { new Guid("b3e72daa-f253-4895-a9fb-7bd2292a64bc"), "NASM" },
                    { new Guid("b76dc387-2070-4f90-a020-f9412f639454"), "ACSM" },
                    { new Guid("d1552a77-25de-4e61-b4ff-4d2ce1235876"), "ISSA" },
                    { new Guid("f36d1c84-bd0d-43e4-8890-ed26c97faabb"), "ACE" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "HasBeenEdited", "IsActive", "TaggedUser", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("0885b928-7821-45c2-bd56-b41333d0b0fe"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Hi! I don't understand how to do the 5/3/1 workout. Can a coach instruct me how to do it?", new Guid("199850bc-ea29-43b0-b342-a11a7fc6cc8c") },
                    { new Guid("8d80c086-2354-4d24-b02d-507d76f61e8f"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Welcome to The Lifting Dome! The No.1 place for fitness and health! Feel free to browse through the published workouts and try some out, or become a coach yourself and create new workouts!", new Guid("d659b40a-2c01-417f-a452-19b194b2c081") }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "CreatedOn", "Description", "HasBeenEdited", "ImageURL", "IsActive", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("5351299a-69a6-43f1-940c-63a995d5ed93"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", false, "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", false, 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("671c58c5-8d56-42f8-8f49-6cc44f745df3"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", false, "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", false, 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("c6004b2d-2c20-45d9-9562-93bc6e0de18a"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The best way for beginner and intermediate strength athletes to build strength.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", false, 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 },
                    { new Guid("d60fcc11-6d56-4e40-8ed9-2c9aa6763d17"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", false, "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", false, 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 }
                });
        }
    }
}

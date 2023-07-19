using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftingDome.Data.Migrations
{
    public partial class AddIsActiveColumnForSoftDeletingWorkouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("118f1bb3-ab34-4947-9ea4-ecc965db06ae"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("6b680230-9c4e-4386-9d72-d7b10461b359"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("74c6b178-f585-4071-882a-a0c0b156a975"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("fd95f920-05d1-47c6-983f-1cf1db54a3d0"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Workouts",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "Description", "ImageURL", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("9139239e-3aba-4d24-ac2e-549a36152c6d"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("b8046ea0-29e7-4eb5-b850-900c5bb7d8de"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("ec6717a1-643f-47e2-8826-1c391c3a3735"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 },
                    { new Guid("fa1bf71c-f790-4430-b8e4-50fb3df366be"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "The best way for beginner and intermediate strength athletes to build strength.", "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("9139239e-3aba-4d24-ac2e-549a36152c6d"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("b8046ea0-29e7-4eb5-b850-900c5bb7d8de"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("ec6717a1-643f-47e2-8826-1c391c3a3735"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("fa1bf71c-f790-4430-b8e4-50fb3df366be"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Workouts");

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "CreatedOn", "Description", "ImageURL", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("118f1bb3-ab34-4947-9ea4-ecc965db06ae"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("6b680230-9c4e-4386-9d72-d7b10461b359"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 },
                    { new Guid("74c6b178-f585-4071-882a-a0c0b156a975"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The best way for beginner and intermediate strength athletes to build strength.", "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 },
                    { new Guid("fd95f920-05d1-47c6-983f-1cf1db54a3d0"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 }
                });
        }
    }
}

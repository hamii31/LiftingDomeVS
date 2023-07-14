using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftingDome.Data.Migrations
{
    public partial class AddCalculatorMeassurmentSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("1f67a4ed-726c-44c2-ba8a-295f930fcf13"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3b749ca7-25ac-464d-b19c-623d9afea052"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("3dca11b8-2a97-4605-9200-3038ec9f689b"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("4b92a67e-a05e-4e86-b082-7336da12fbe1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 14, 9, 46, 4, 581, DateTimeKind.Utc).AddTicks(615),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 10, 13, 9, 19, 164, DateTimeKind.Utc).AddTicks(7842));

            migrationBuilder.CreateTable(
                name: "CalculatorMeassurments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatorMeassurments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CalculatorMeassurments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Metric" },
                    { 2, "Imperial" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "Description", "ImageURL", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("038b877c-3254-4609-b790-12c465c91c0f"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("1a552c28-d08e-461c-bd7b-77419a838c2a"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("7763cbff-3c3b-4fe2-9857-137b4a9c70c2"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "The best way for beginner and intermediate strength athletes to build strength.", "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 },
                    { new Guid("ae8de2b1-ff03-4453-9f51-8b1d46ee18a1"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatorMeassurments");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("038b877c-3254-4609-b790-12c465c91c0f"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("1a552c28-d08e-461c-bd7b-77419a838c2a"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("7763cbff-3c3b-4fe2-9857-137b4a9c70c2"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("ae8de2b1-ff03-4453-9f51-8b1d46ee18a1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 10, 13, 9, 19, 164, DateTimeKind.Utc).AddTicks(7842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 14, 9, 46, 4, 581, DateTimeKind.Utc).AddTicks(615));

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CoachId", "CreatedOn", "Description", "ImageURL", "Price", "Title", "TraineeId", "WorkoutCategoryId" },
                values: new object[,]
                {
                    { new Guid("1f67a4ed-726c-44c2-ba8a-295f930fcf13"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.", "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg", 0m, "The 5X5 Method for size and strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 },
                    { new Guid("3b749ca7-25ac-464d-b19c-623d9afea052"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.", "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg", 20m, "CrossFit for Meatheads", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 3 },
                    { new Guid("3dca11b8-2a97-4605-9200-3038ec9f689b"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The best way for beginner and intermediate strength athletes to build strength.", "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg", 0m, "3X3 at 90% for pure strength", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 1 },
                    { new Guid("4b92a67e-a05e-4e86-b082-7336da12fbe1"), new Guid("09cd637a-3447-4f2f-bbf0-5ba9cb561209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.", "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg", 0m, "The 4x8 rep scheme for unmatched muscle mass!", new Guid("badf1763-a2f6-4844-3189-08db7fb398c0"), 2 }
                });
        }
    }
}

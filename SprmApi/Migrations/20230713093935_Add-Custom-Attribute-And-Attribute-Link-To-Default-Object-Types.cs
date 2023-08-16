using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomAttributeAndAttributeLinkToDefaultObjectTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(646), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(654), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(655) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(704), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(739), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(742), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(742) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(744), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(744) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(746), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(746) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(748), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(748) });

            migrationBuilder.InsertData(
                schema: "sprm",
                table: "object_types",
                columns: new[] { "id", "create_date", "create_user", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 7L, new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(749), "system", "自訂屬性", "CustomAttribute", "自訂屬性", new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(750), "system" },
                    { 8L, new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(752), "system", "屬性連結", "AttributeLink", "屬性連結", new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(752), "system" }
                });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(676), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(676) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(679), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(681), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(682), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(683) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3327), new Dictionary<string, string>(), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3334), new Dictionary<string, string>(), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3334) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3413), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3413) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3419), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3419) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3420), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3422), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3422) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3423), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3424) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3426), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3427) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3390), new Dictionary<string, string>(), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3390) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3392), new Dictionary<string, string>(), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3393) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3394), new Dictionary<string, string>(), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3394) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3395), new Dictionary<string, string>(), new DateTime(2023, 7, 12, 3, 12, 34, 597, DateTimeKind.Utc).AddTicks(3395) });
        }
    }
}

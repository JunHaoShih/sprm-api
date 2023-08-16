using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeObjectTypeName : Migration
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
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8544), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8546) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8549), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8549) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8593), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8593) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8596), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8597) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "name", "remarks", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8598), "工藝路徑", "工藝路徑", new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8598) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "name", "remarks", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8599), "工藝路徑版本", "工藝路徑版本", new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8599) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8603), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "name", "remarks", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8605), "工藝路徑使用關係", "工藝路徑使用關係", new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8571), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8571) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8573), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8574) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8574), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8575) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8575), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8576) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1218), new Dictionary<string, string>(), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1222) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1226), new Dictionary<string, string>(), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1226) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1273), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1274) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1277), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1277) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "name", "remarks", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1279), "產品途程", "產品途程", new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1279) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "name", "remarks", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1280), "產品途程版本", "產品途程版本", new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1281), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1282) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "name", "remarks", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1285), "途程之製程", "途程之製程", new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1285) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1250), new Dictionary<string, string>(), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1253), new Dictionary<string, string>(), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1253) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1254), new Dictionary<string, string>(), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1254) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1255), new Dictionary<string, string>(), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1256) });
        }
    }
}

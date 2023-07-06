using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRoutingUsageParentForeignKey : Migration
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
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1279), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1279) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1280), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1280) });

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
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1285), new DateTime(2023, 6, 27, 9, 40, 26, 14, DateTimeKind.Utc).AddTicks(1285) });

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

            migrationBuilder.CreateIndex(
                name: "IX_routing_usages_parent_usage_id",
                schema: "sprm",
                table: "routing_usages",
                column: "parent_usage_id");

            migrationBuilder.AddForeignKey(
                name: "FK_routing_usages_routing_usages_parent_usage_id",
                schema: "sprm",
                table: "routing_usages",
                column: "parent_usage_id",
                principalSchema: "sprm",
                principalTable: "routing_usages",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_routing_usages_routing_usages_parent_usage_id",
                schema: "sprm",
                table: "routing_usages");

            migrationBuilder.DropIndex(
                name: "IX_routing_usages_parent_usage_id",
                schema: "sprm",
                table: "routing_usages");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6207), new Dictionary<string, string>(), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6209) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6212), new Dictionary<string, string>(), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6253), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6253) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6258), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6259) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6260), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6261), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6261) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6262), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6263) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6265), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6265) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6231), new Dictionary<string, string>(), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6231) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6233), new Dictionary<string, string>(), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6233) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6234), new Dictionary<string, string>(), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6235) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6235), new Dictionary<string, string>(), new DateTime(2023, 6, 26, 2, 55, 10, 498, DateTimeKind.Utc).AddTicks(6236) });
        }
    }
}

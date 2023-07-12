using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class PermissionsAddUniqueKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_permissions_user_id",
                schema: "sprm",
                table: "permissions");

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

            migrationBuilder.CreateIndex(
                name: "IX_permissions_user_id_object_type_id",
                schema: "sprm",
                table: "permissions",
                columns: new[] { "user_id", "object_type_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_permissions_user_id_object_type_id",
                schema: "sprm",
                table: "permissions");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1211), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1215) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1219), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1267), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1267) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1272), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1272) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1274), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1274) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1275), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1275) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1277), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1277) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1279), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1243), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1243) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1246), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1246) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1247), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1247) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1248), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1249) });

            migrationBuilder.CreateIndex(
                name: "IX_permissions_user_id",
                schema: "sprm",
                table: "permissions",
                column: "user_id");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class PartVersion_Add_IsDraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_routing_versions_master_id_version_checkout",
                schema: "sprm",
                table: "routing_versions");

            migrationBuilder.DropIndex(
                name: "IX_part_versions_master_id_version_checkout",
                schema: "sprm",
                table: "part_versions");

            migrationBuilder.DropColumn(
                name: "checkout",
                schema: "sprm",
                table: "routing_versions");

            migrationBuilder.DropColumn(
                name: "checkout",
                schema: "sprm",
                table: "part_versions");

            migrationBuilder.AddColumn<bool>(
                name: "is_draft",
                schema: "sprm",
                table: "routing_versions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "是否為草稿");

            migrationBuilder.AddColumn<bool>(
                name: "is_draft",
                schema: "sprm",
                table: "part_versions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "是否為草稿");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4575), new Dictionary<string, string>(), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4583), new Dictionary<string, string>(), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4583) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4667), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4667) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4673), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4673) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4676), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4677), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4678) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4679), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4679) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4682), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4683) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4602), new Dictionary<string, string>(), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4602) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4604), new Dictionary<string, string>(), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4605) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4651), new Dictionary<string, string>(), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4651) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4653), new Dictionary<string, string>(), new DateTime(2023, 6, 12, 3, 14, 22, 54, DateTimeKind.Utc).AddTicks(4653) });

            migrationBuilder.CreateIndex(
                name: "IX_routing_versions_master_id_version",
                schema: "sprm",
                table: "routing_versions",
                columns: new[] { "master_id", "version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_part_versions_master_id_version",
                schema: "sprm",
                table: "part_versions",
                columns: new[] { "master_id", "version" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_routing_versions_master_id_version",
                schema: "sprm",
                table: "routing_versions");

            migrationBuilder.DropIndex(
                name: "IX_part_versions_master_id_version",
                schema: "sprm",
                table: "part_versions");

            migrationBuilder.DropColumn(
                name: "is_draft",
                schema: "sprm",
                table: "routing_versions");

            migrationBuilder.DropColumn(
                name: "is_draft",
                schema: "sprm",
                table: "part_versions");

            migrationBuilder.AddColumn<bool>(
                name: "checkout",
                schema: "sprm",
                table: "routing_versions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "是否出庫");

            migrationBuilder.AddColumn<bool>(
                name: "checkout",
                schema: "sprm",
                table: "part_versions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "是否出庫");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8670), new Dictionary<string, string>(), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8675) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8677), new Dictionary<string, string>(), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8677) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8721), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8722) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8726), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8726) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8727), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8727) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8728), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8728) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8730), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8730) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8732), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8732) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8700), new Dictionary<string, string>(), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8702), new Dictionary<string, string>(), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8702) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8703), new Dictionary<string, string>(), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8703) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8704), new Dictionary<string, string>(), new DateTime(2023, 6, 2, 3, 6, 19, 662, DateTimeKind.Utc).AddTicks(8705) });

            migrationBuilder.CreateIndex(
                name: "IX_routing_versions_master_id_version_checkout",
                schema: "sprm",
                table: "routing_versions",
                columns: new[] { "master_id", "version", "checkout" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_part_versions_master_id_version_checkout",
                schema: "sprm",
                table: "part_versions",
                columns: new[] { "master_id", "version", "checkout" },
                unique: true);
        }
    }
}

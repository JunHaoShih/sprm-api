using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class Change_PartUsage_Column_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_part_usages_part_versions_used_by",
                schema: "sprm",
                table: "part_usages");

            migrationBuilder.DropForeignKey(
                name: "FK_part_usages_parts_uses",
                schema: "sprm",
                table: "part_usages");

            migrationBuilder.RenameColumn(
                name: "uses",
                schema: "sprm",
                table: "part_usages",
                newName: "child_id");

            migrationBuilder.RenameColumn(
                name: "used_by",
                schema: "sprm",
                table: "part_usages",
                newName: "parent_id");

            migrationBuilder.RenameIndex(
                name: "IX_part_usages_uses",
                schema: "sprm",
                table: "part_usages",
                newName: "IX_part_usages_child_id");

            migrationBuilder.RenameIndex(
                name: "IX_part_usages_used_by_uses",
                schema: "sprm",
                table: "part_usages",
                newName: "IX_part_usages_parent_id_child_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_part_usages_part_versions_parent_id",
                schema: "sprm",
                table: "part_usages",
                column: "parent_id",
                principalSchema: "sprm",
                principalTable: "part_versions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_part_usages_parts_child_id",
                schema: "sprm",
                table: "part_usages",
                column: "child_id",
                principalSchema: "sprm",
                principalTable: "parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_part_usages_part_versions_parent_id",
                schema: "sprm",
                table: "part_usages");

            migrationBuilder.DropForeignKey(
                name: "FK_part_usages_parts_child_id",
                schema: "sprm",
                table: "part_usages");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                schema: "sprm",
                table: "part_usages",
                newName: "used_by");

            migrationBuilder.RenameColumn(
                name: "child_id",
                schema: "sprm",
                table: "part_usages",
                newName: "uses");

            migrationBuilder.RenameIndex(
                name: "IX_part_usages_parent_id_child_id",
                schema: "sprm",
                table: "part_usages",
                newName: "IX_part_usages_used_by_uses");

            migrationBuilder.RenameIndex(
                name: "IX_part_usages_child_id",
                schema: "sprm",
                table: "part_usages",
                newName: "IX_part_usages_uses");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4222), new Dictionary<string, string>(), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4229), new Dictionary<string, string>(), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4229) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4331), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4331) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4337), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4338) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4340), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4341), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4342) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4343), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4343) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4346), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4347) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4254), new Dictionary<string, string>(), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4257), new Dictionary<string, string>(), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4258), new Dictionary<string, string>(), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4259), new Dictionary<string, string>(), new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.AddForeignKey(
                name: "FK_part_usages_part_versions_used_by",
                schema: "sprm",
                table: "part_usages",
                column: "used_by",
                principalSchema: "sprm",
                principalTable: "part_versions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_part_usages_parts_uses",
                schema: "sprm",
                table: "part_usages",
                column: "uses",
                principalSchema: "sprm",
                principalTable: "parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

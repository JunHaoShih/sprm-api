using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Foreign_Key_Constraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_part_usages_parts_child_id",
                schema: "sprm",
                table: "part_usages");

            migrationBuilder.DropForeignKey(
                name: "FK_processes_make_types_default_make_type_id",
                schema: "sprm",
                table: "processes");

            migrationBuilder.DropForeignKey(
                name: "FK_processes_process_types_process_type_id",
                schema: "sprm",
                table: "processes");

            migrationBuilder.DropForeignKey(
                name: "FK_routings_parts_part_id",
                schema: "sprm",
                table: "routings");

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

            migrationBuilder.AddForeignKey(
                name: "FK_part_usages_parts_child_id",
                schema: "sprm",
                table: "part_usages",
                column: "child_id",
                principalSchema: "sprm",
                principalTable: "parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_processes_make_types_default_make_type_id",
                schema: "sprm",
                table: "processes",
                column: "default_make_type_id",
                principalSchema: "sprm",
                principalTable: "make_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_processes_process_types_process_type_id",
                schema: "sprm",
                table: "processes",
                column: "process_type_id",
                principalSchema: "sprm",
                principalTable: "process_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_routings_parts_part_id",
                schema: "sprm",
                table: "routings",
                column: "part_id",
                principalSchema: "sprm",
                principalTable: "parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_part_usages_parts_child_id",
                schema: "sprm",
                table: "part_usages");

            migrationBuilder.DropForeignKey(
                name: "FK_processes_make_types_default_make_type_id",
                schema: "sprm",
                table: "processes");

            migrationBuilder.DropForeignKey(
                name: "FK_processes_process_types_process_type_id",
                schema: "sprm",
                table: "processes");

            migrationBuilder.DropForeignKey(
                name: "FK_routings_parts_part_id",
                schema: "sprm",
                table: "routings");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3662), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3664) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3668), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3668) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3705), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3705) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3709), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3711), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3711) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3712), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3712) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3714), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3714) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3716), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3716) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3687), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3687) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3689), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3689) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3690), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3691), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 8, 22, 32, 914, DateTimeKind.Utc).AddTicks(3691) });

            migrationBuilder.AddForeignKey(
                name: "FK_part_usages_parts_child_id",
                schema: "sprm",
                table: "part_usages",
                column: "child_id",
                principalSchema: "sprm",
                principalTable: "parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_processes_make_types_default_make_type_id",
                schema: "sprm",
                table: "processes",
                column: "default_make_type_id",
                principalSchema: "sprm",
                principalTable: "make_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_processes_process_types_process_type_id",
                schema: "sprm",
                table: "processes",
                column: "process_type_id",
                principalSchema: "sprm",
                principalTable: "process_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_routings_parts_part_id",
                schema: "sprm",
                table: "routings",
                column: "part_id",
                principalSchema: "sprm",
                principalTable: "parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

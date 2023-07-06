using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class Process_MakeType_ForignKey_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_processes_make_types_MakeTypeId",
                schema: "sprm",
                table: "processes");

            migrationBuilder.DropIndex(
                name: "IX_processes_MakeTypeId",
                schema: "sprm",
                table: "processes");

            migrationBuilder.DropColumn(
                name: "MakeTypeId",
                schema: "sprm",
                table: "processes");

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

            migrationBuilder.CreateIndex(
                name: "IX_processes_default_make_type_id",
                schema: "sprm",
                table: "processes",
                column: "default_make_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_processes_make_types_default_make_type_id",
                schema: "sprm",
                table: "processes",
                column: "default_make_type_id",
                principalSchema: "sprm",
                principalTable: "make_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_processes_make_types_default_make_type_id",
                schema: "sprm",
                table: "processes");

            migrationBuilder.DropIndex(
                name: "IX_processes_default_make_type_id",
                schema: "sprm",
                table: "processes");

            migrationBuilder.AddColumn<long>(
                name: "MakeTypeId",
                schema: "sprm",
                table: "processes",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1518), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1521) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1530), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1531) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1583), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1584) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1590), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1590) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1592), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1592) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1594), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1594) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1596), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1596) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1600), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1600) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1555), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1555) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1559), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1559) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1561), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1561) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1563), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 7, 51, 22, 299, DateTimeKind.Utc).AddTicks(1563) });

            migrationBuilder.CreateIndex(
                name: "IX_processes_MakeTypeId",
                schema: "sprm",
                table: "processes",
                column: "MakeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_processes_make_types_MakeTypeId",
                schema: "sprm",
                table: "processes",
                column: "MakeTypeId",
                principalSchema: "sprm",
                principalTable: "make_types",
                principalColumn: "id");
        }
    }
}

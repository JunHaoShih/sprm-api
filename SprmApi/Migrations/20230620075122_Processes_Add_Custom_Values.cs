using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Text.Json;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class Processes_Add_Custom_Values : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "default_import_time",
                schema: "sprm",
                table: "processes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "預設上料工時(毫秒)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "預設上料工時(毫秒)");

            migrationBuilder.AlterColumn<int>(
                name: "default_export_time",
                schema: "sprm",
                table: "processes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "預設下料工時(毫秒)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldComment: "預設下料工時(毫秒)");

            migrationBuilder.AddColumn<JsonDocument>(
                name: "custom_values",
                schema: "sprm",
                table: "processes",
                type: "jsonb",
                nullable: false,
                comment: "自訂屬性值");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "custom_values",
                schema: "sprm",
                table: "processes");

            migrationBuilder.AlterColumn<int>(
                name: "default_import_time",
                schema: "sprm",
                table: "processes",
                type: "integer",
                nullable: true,
                comment: "預設上料工時(毫秒)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "預設上料工時(毫秒)");

            migrationBuilder.AlterColumn<int>(
                name: "default_export_time",
                schema: "sprm",
                table: "processes",
                type: "integer",
                nullable: true,
                comment: "預設下料工時(毫秒)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "預設下料工時(毫秒)");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(629), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(631) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(637), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(638) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(677), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(677) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(680), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(682), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(682) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(683), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(683) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(684), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(685) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(686), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(686) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(656), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(657) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(659), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(659) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(660), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(661), new Dictionary<string, string>(), new DateTime(2023, 6, 20, 6, 22, 56, 330, DateTimeKind.Utc).AddTicks(661) });
        }
    }
}

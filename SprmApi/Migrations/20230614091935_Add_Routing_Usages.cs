using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class Add_Routing_Usages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "routings",
                schema: "sprm",
                comment: "工藝路徑",
                oldComment: "產品途程");

            migrationBuilder.AlterTable(
                name: "routing_versions",
                schema: "sprm",
                comment: "工藝路徑版本",
                oldComment: "產品途程版本");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "sprm",
                table: "routings",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "工藝路徑名稱",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldComment: "產品途程名稱");

            migrationBuilder.AlterColumn<bool>(
                name: "is_default",
                schema: "sprm",
                table: "routings",
                type: "boolean",
                nullable: false,
                comment: "是否為預設工藝路徑",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "是否為預設途程");

            migrationBuilder.AddColumn<bool>(
                name: "checkout",
                schema: "sprm",
                table: "routings",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "是否簽出");

            migrationBuilder.AddColumn<JsonDocument>(
                name: "custom_values",
                schema: "sprm",
                table: "routing_versions",
                type: "jsonb",
                nullable: false,
                comment: "自訂屬性值");

            migrationBuilder.AlterColumn<bool>(
                name: "checkout",
                schema: "sprm",
                table: "parts",
                type: "boolean",
                nullable: false,
                comment: "是否簽出",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "是否出庫");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6219), new Dictionary<string, string>(), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6223) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6226), new Dictionary<string, string>(), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6227) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6314), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6314) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6319), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6319) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6320), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6321) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6322), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6322) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6323), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6324) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6326), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6326) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6254), new Dictionary<string, string>(), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6254) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6257), new Dictionary<string, string>(), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6257) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6258), new Dictionary<string, string>(), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6258) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6259), new Dictionary<string, string>(), new DateTime(2023, 6, 14, 9, 19, 34, 832, DateTimeKind.Utc).AddTicks(6259) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "checkout",
                schema: "sprm",
                table: "routings");

            migrationBuilder.DropColumn(
                name: "custom_values",
                schema: "sprm",
                table: "routing_versions");

            migrationBuilder.AlterTable(
                name: "routings",
                schema: "sprm",
                comment: "產品途程",
                oldComment: "工藝路徑");

            migrationBuilder.AlterTable(
                name: "routing_versions",
                schema: "sprm",
                comment: "產品途程版本",
                oldComment: "工藝路徑版本");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "sprm",
                table: "routings",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "產品途程名稱",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldComment: "工藝路徑名稱");

            migrationBuilder.AlterColumn<bool>(
                name: "is_default",
                schema: "sprm",
                table: "routings",
                type: "boolean",
                nullable: false,
                comment: "是否為預設途程",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "是否為預設工藝路徑");

            migrationBuilder.AlterColumn<bool>(
                name: "checkout",
                schema: "sprm",
                table: "parts",
                type: "boolean",
                nullable: false,
                comment: "是否出庫",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "是否簽出");

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
        }
    }
}

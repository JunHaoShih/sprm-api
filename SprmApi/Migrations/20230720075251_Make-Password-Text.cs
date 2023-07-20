using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class MakePasswordText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password",
                schema: "sprm",
                table: "app_users",
                type: "text",
                nullable: false,
                comment: "Password hash",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 100,
                oldComment: "Password hash");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "custom_values",
                schema: "sprm",
                table: "app_users",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "自訂屬性值",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "自訂屬性值");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9149), new Dictionary<string, string>(), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9152) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9159), new Dictionary<string, string>(), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9205), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9206) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9210), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9211) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9212), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9212) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9213), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9213) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9215), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9215) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9218), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9218) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 7L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9219), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9219) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 8L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9221), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 9L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9223), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9182), new Dictionary<string, string>(), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9182) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9184), new Dictionary<string, string>(), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9185), new Dictionary<string, string>(), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9185) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9186), new Dictionary<string, string>(), new DateTime(2023, 7, 20, 7, 52, 51, 591, DateTimeKind.Utc).AddTicks(9186) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password",
                schema: "sprm",
                table: "app_users",
                type: "varchar(50)",
                maxLength: 100,
                nullable: false,
                comment: "Password hash",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Password hash");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "custom_values",
                schema: "sprm",
                table: "app_users",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "自訂屬性值",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "自訂屬性值");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3173), new Dictionary<string, string>(), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3176) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3182), new Dictionary<string, string>(), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3182) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3257), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3258) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3265), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3266) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3267), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3268) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3269), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3271), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3272) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3278), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3278) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 7L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3280), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 8L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3284), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3284) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 9L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3287), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3287) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3222), new Dictionary<string, string>(), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3222) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3227), new Dictionary<string, string>(), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3227) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3229), new Dictionary<string, string>(), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3229) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3230), new Dictionary<string, string>(), new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3230) });
        }
    }
}

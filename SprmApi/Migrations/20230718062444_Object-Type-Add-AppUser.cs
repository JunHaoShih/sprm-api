using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class ObjectTypeAddAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<JsonDocument>(
                name: "custom_values",
                schema: "sprm",
                table: "app_users",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "自訂屬性值");

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

            migrationBuilder.InsertData(
                schema: "sprm",
                table: "object_types",
                columns: new[] { "id", "create_date", "create_user", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[] { 9L, new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3287), "system", "App使用者", "AppUser", "App使用者", new DateTime(2023, 7, 18, 6, 24, 44, 212, DateTimeKind.Utc).AddTicks(3287), "system" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DropColumn(
                name: "custom_values",
                schema: "sprm",
                table: "app_users");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(646), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(654), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(655) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(704), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(739), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(742), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(742) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(744), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(744) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(746), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(746) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(748), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(748) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 7L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(749), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 8L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(752), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(752) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(676), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(676) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(679), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(681), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(682), new Dictionary<string, string>(), new DateTime(2023, 7, 13, 9, 39, 35, 60, DateTimeKind.Utc).AddTicks(683) });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class RestrictRoutingUsageProcessForeignKeyDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_routing_usages_processes_process_id",
                schema: "sprm",
                table: "routing_usages");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3537), new Dictionary<string, string>(), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3541) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3546), new Dictionary<string, string>(), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3547) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3619), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3619) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3626), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3626) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3628), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3629) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3631), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3631) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3634), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3635) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3638), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3639) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3583), new Dictionary<string, string>(), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3583) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3586), new Dictionary<string, string>(), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3587) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3589), new Dictionary<string, string>(), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3589) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3591), new Dictionary<string, string>(), new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3592) });

            migrationBuilder.AddForeignKey(
                name: "FK_routing_usages_processes_process_id",
                schema: "sprm",
                table: "routing_usages",
                column: "process_id",
                principalSchema: "sprm",
                principalTable: "processes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_routing_usages_processes_process_id",
                schema: "sprm",
                table: "routing_usages");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8544), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8546) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8549), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8549) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8593), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8593) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8596), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8597) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8598), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8598) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8599), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8599) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8603), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8605), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8571), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8571) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8573), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8574) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8574), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8575) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8575), new Dictionary<string, string>(), new DateTime(2023, 6, 30, 2, 17, 20, 2, DateTimeKind.Utc).AddTicks(8576) });

            migrationBuilder.AddForeignKey(
                name: "FK_routing_usages_processes_process_id",
                schema: "sprm",
                table: "routing_usages",
                column: "process_id",
                principalSchema: "sprm",
                principalTable: "processes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

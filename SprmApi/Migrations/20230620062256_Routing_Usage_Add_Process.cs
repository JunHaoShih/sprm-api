using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Text.Json;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class Routing_Usage_Add_Process : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "routing_usages",
                schema: "sprm",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "system id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    create_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "Creator"),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Create date"),
                    update_user = table.Column<string>(type: "varchar(50)", nullable: false, comment: "Updator"),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Update date"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "Remarks"),
                    root_version_id = table.Column<long>(type: "bigint", nullable: false, comment: "該使用關係所屬工藝路徑版本的id"),
                    parent_usage_id = table.Column<long>(type: "bigint", nullable: true, comment: "該使用關係所屬的父使用關係id"),
                    number = table.Column<string>(type: "text", nullable: false, comment: "使用關係編號"),
                    process_id = table.Column<long>(type: "bigint", nullable: false, comment: "製程id"),
                    custom_values = table.Column<JsonDocument>(type: "jsonb", nullable: false, comment: "自訂屬性值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routing_usages", x => x.id);
                    table.ForeignKey(
                        name: "FK_routing_usages_processes_process_id",
                        column: x => x.process_id,
                        principalSchema: "sprm",
                        principalTable: "processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_routing_usages_routing_versions_root_version_id",
                        column: x => x.root_version_id,
                        principalSchema: "sprm",
                        principalTable: "routing_versions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "工藝路徑使用關係");

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

            migrationBuilder.CreateIndex(
                name: "IX_routing_usages_process_id",
                schema: "sprm",
                table: "routing_usages",
                column: "process_id");

            migrationBuilder.CreateIndex(
                name: "IX_routing_usages_root_version_id_number",
                schema: "sprm",
                table: "routing_usages",
                columns: new[] { "root_version_id", "number" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "routing_usages",
                schema: "sprm");

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
    }
}

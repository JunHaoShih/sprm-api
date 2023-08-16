using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoutingProcesses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "routing_processes",
                schema: "sprm");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3176), new Dictionary<string, string>(), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3178) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3183), new Dictionary<string, string>(), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3183) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3287), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3287) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3294), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3294) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3295), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3295) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3296), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3297) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3300), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "number", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3303), "RoutingUsage", new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3303) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3212), new Dictionary<string, string>(), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3212) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3262), new Dictionary<string, string>(), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3262) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3264), new Dictionary<string, string>(), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3264) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3265), new Dictionary<string, string>(), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3266) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "routing_processes",
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
                    make_type_id = table.Column<long>(type: "bigint", nullable: false, comment: "製造類型id"),
                    process_id = table.Column<long>(type: "bigint", nullable: false, comment: "製程id"),
                    routing_version_id = table.Column<long>(type: "bigint", nullable: false, comment: "途程版本id"),
                    export_time = table.Column<int>(type: "integer", nullable: true, comment: "下料工時(毫秒)"),
                    import_time = table.Column<int>(type: "integer", nullable: true, comment: "上料工時(毫秒)"),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "途程內編號"),
                    order = table.Column<int>(type: "integer", nullable: false, comment: "製程順序")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routing_processes", x => x.id);
                    table.ForeignKey(
                        name: "FK_routing_processes_make_types_make_type_id",
                        column: x => x.make_type_id,
                        principalSchema: "sprm",
                        principalTable: "make_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_routing_processes_processes_process_id",
                        column: x => x.process_id,
                        principalSchema: "sprm",
                        principalTable: "processes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_routing_processes_routing_versions_routing_version_id",
                        column: x => x.routing_version_id,
                        principalSchema: "sprm",
                        principalTable: "routing_versions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "途程之製程");

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
                columns: new[] { "create_date", "number", "update_date" },
                values: new object[] { new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3638), "RoutingProcess", new DateTime(2023, 7, 5, 7, 35, 47, 435, DateTimeKind.Utc).AddTicks(3639) });

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

            migrationBuilder.CreateIndex(
                name: "IX_routing_processes_make_type_id",
                schema: "sprm",
                table: "routing_processes",
                column: "make_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_routing_processes_process_id",
                schema: "sprm",
                table: "routing_processes",
                column: "process_id");

            migrationBuilder.CreateIndex(
                name: "IX_routing_processes_routing_version_id_number",
                schema: "sprm",
                table: "routing_processes",
                columns: new[] { "routing_version_id", "number" },
                unique: true);
        }
    }
}

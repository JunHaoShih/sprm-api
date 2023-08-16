using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SprmApi.Core.Customs;
using System;
using System.Text.Json;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class First_Version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sprm");

            migrationBuilder.CreateTable(
                name: "app_users",
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
                    username = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "App使用者名稱"),
                    password = table.Column<string>(type: "varchar(50)", maxLength: 100, nullable: false, comment: "Password hash"),
                    full_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "App使用者姓名")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_users", x => x.id);
                },
                comment: "App使用者");

            migrationBuilder.CreateTable(
                name: "custom_attributes",
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
                    attribute_type = table.Column<int>(type: "integer", nullable: false, comment: "自訂屬性類型"),
                    display_type = table.Column<int>(type: "integer", nullable: false, comment: "自訂屬性顯示類型"),
                    is_disabled = table.Column<bool>(type: "boolean", nullable: false, comment: "是否停用"),
                    options = table.Column<IEnumerable<CustomOption>>(type: "jsonb", nullable: false, comment: "自訂選項"),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "編號"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "名稱"),
                    is_system_default = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為系統預設"),
                    languages = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false, comment: "語系與對應翻譯")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custom_attributes", x => x.id);
                },
                comment: "自訂屬性");

            migrationBuilder.CreateTable(
                name: "make_types",
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
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "編號"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "名稱"),
                    is_system_default = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為系統預設"),
                    languages = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false, comment: "語系與對應翻譯")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_make_types", x => x.id);
                },
                comment: "製造類型");

            migrationBuilder.CreateTable(
                name: "object_types",
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
                    number = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, comment: "物件類型編號"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "物件名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_object_types", x => x.id);
                },
                comment: "物件類型");

            migrationBuilder.CreateTable(
                name: "parts",
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
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "料號"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "零件名稱"),
                    view_type = table.Column<int>(type: "integer", nullable: false, comment: "視圖類型"),
                    checkout = table.Column<bool>(type: "boolean", nullable: false, comment: "是否出庫")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.id);
                },
                comment: "零件");

            migrationBuilder.CreateTable(
                name: "process_types",
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
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "編號"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "名稱"),
                    is_system_default = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為系統預設"),
                    languages = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false, comment: "語系與對應翻譯")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_process_types", x => x.id);
                },
                comment: "製程類型");

            migrationBuilder.CreateTable(
                name: "attribute_links",
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
                    object_type_id = table.Column<long>(type: "bigint", nullable: false, comment: "物件類型id"),
                    attribute_id = table.Column<long>(type: "bigint", nullable: false, comment: "自訂屬性id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attribute_links", x => x.id);
                    table.ForeignKey(
                        name: "FK_attribute_links_custom_attributes_attribute_id",
                        column: x => x.attribute_id,
                        principalSchema: "sprm",
                        principalTable: "custom_attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attribute_links_object_types_object_type_id",
                        column: x => x.object_type_id,
                        principalSchema: "sprm",
                        principalTable: "object_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "類型屬性");

            migrationBuilder.CreateTable(
                name: "part_versions",
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
                    custom_values = table.Column<JsonDocument>(type: "jsonb", nullable: false, comment: "自訂屬性值"),
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "master id"),
                    version = table.Column<int>(type: "integer", nullable: false, comment: "版本號"),
                    is_latest = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為最新版"),
                    checkout = table.Column<bool>(type: "boolean", nullable: false, comment: "是否出庫")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part_versions", x => x.id);
                    table.ForeignKey(
                        name: "FK_part_versions_parts_master_id",
                        column: x => x.master_id,
                        principalSchema: "sprm",
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "零件");

            migrationBuilder.CreateTable(
                name: "routings",
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
                    part_id = table.Column<long>(type: "bigint", nullable: false, comment: "對應料件id"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "產品途程名稱"),
                    is_default = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為預設途程")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routings", x => x.id);
                    table.ForeignKey(
                        name: "FK_routings_parts_part_id",
                        column: x => x.part_id,
                        principalSchema: "sprm",
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "產品途程");

            migrationBuilder.CreateTable(
                name: "processes",
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
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "製程代碼"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "製程名稱"),
                    process_type_id = table.Column<long>(type: "bigint", nullable: false, comment: "製程類型id"),
                    default_import_time = table.Column<int>(type: "integer", nullable: true, comment: "預設上料工時(毫秒)"),
                    default_export_time = table.Column<int>(type: "integer", nullable: true, comment: "預設下料工時(毫秒)"),
                    default_make_type_id = table.Column<long>(type: "bigint", nullable: false, comment: "預設製造類型id"),
                    MakeTypeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processes", x => x.id);
                    table.ForeignKey(
                        name: "FK_processes_make_types_MakeTypeId",
                        column: x => x.MakeTypeId,
                        principalSchema: "sprm",
                        principalTable: "make_types",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_processes_process_types_process_type_id",
                        column: x => x.process_type_id,
                        principalSchema: "sprm",
                        principalTable: "process_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "製程");

            migrationBuilder.CreateTable(
                name: "part_usages",
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
                    used_by = table.Column<long>(type: "bigint", nullable: false, comment: "父零件版本id"),
                    uses = table.Column<long>(type: "bigint", nullable: false, comment: "子零件id"),
                    quantity = table.Column<int>(type: "integer", nullable: false, comment: "使用數量"),
                    custom_values = table.Column<JsonDocument>(type: "jsonb", nullable: false, comment: "自訂屬性值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part_usages", x => x.id);
                    table.ForeignKey(
                        name: "FK_part_usages_part_versions_used_by",
                        column: x => x.used_by,
                        principalSchema: "sprm",
                        principalTable: "part_versions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_part_usages_parts_uses",
                        column: x => x.uses,
                        principalSchema: "sprm",
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "零件使用關係");

            migrationBuilder.CreateTable(
                name: "routing_versions",
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
                    master_id = table.Column<long>(type: "bigint", nullable: false, comment: "master id"),
                    version = table.Column<int>(type: "integer", nullable: false, comment: "版本號"),
                    is_latest = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為最新版"),
                    checkout = table.Column<bool>(type: "boolean", nullable: false, comment: "是否出庫")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routing_versions", x => x.id);
                    table.ForeignKey(
                        name: "FK_routing_versions_routings_master_id",
                        column: x => x.master_id,
                        principalSchema: "sprm",
                        principalTable: "routings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "產品途程版本");

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
                    routing_version_id = table.Column<long>(type: "bigint", nullable: false, comment: "途程版本id"),
                    number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "途程內編號"),
                    process_id = table.Column<long>(type: "bigint", nullable: false, comment: "製程id"),
                    order = table.Column<int>(type: "integer", nullable: false, comment: "製程順序"),
                    import_time = table.Column<int>(type: "integer", nullable: true, comment: "上料工時(毫秒)"),
                    export_time = table.Column<int>(type: "integer", nullable: true, comment: "下料工時(毫秒)"),
                    make_type_id = table.Column<long>(type: "bigint", nullable: false, comment: "製造類型id")
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

            migrationBuilder.InsertData(
                schema: "sprm",
                table: "make_types",
                columns: new[] { "id", "create_date", "create_user", "is_system_default", "languages", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4222), "system", true, new Dictionary<string, string>(), "自製", "SPRM_SELF_MADE", "System default, do not modify it", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4225), "system" },
                    { 2L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4229), "system", true, new Dictionary<string, string>(), "外包", "SPRM_OUTSOURCE", "System default, do not modify it", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4229), "system" }
                });

            migrationBuilder.InsertData(
                schema: "sprm",
                table: "object_types",
                columns: new[] { "id", "create_date", "create_user", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4331), "system", "料件", "PartVersion", "料件", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4331), "system" },
                    { 2L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4337), "system", "料件使用關係", "PartUsage", "料件使用關係", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4338), "system" },
                    { 3L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4340), "system", "產品途程", "Routing", "產品途程", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4340), "system" },
                    { 4L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4341), "system", "產品途程版本", "RoutingVersion", "產品途程版本", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4342), "system" },
                    { 5L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4343), "system", "製程", "Process", "製程", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4343), "system" },
                    { 6L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4346), "system", "途程之製程", "RoutingProcess", "途程之製程", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4347), "system" }
                });

            migrationBuilder.InsertData(
                schema: "sprm",
                table: "process_types",
                columns: new[] { "id", "create_date", "create_user", "is_system_default", "languages", "name", "number", "remarks", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4254), "system", true, new Dictionary<string, string>(), "加工製程", "SPRM_PROCESSING", "System default, do not modify it", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4254), "system" },
                    { 2L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4257), "system", true, new Dictionary<string, string>(), "檢驗製程", "SPRM_QUALITY_CONTROL", "System default, do not modify it", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4257), "system" },
                    { 3L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4258), "system", true, new Dictionary<string, string>(), "組裝製程", "SPRM_ASSEMBLE", "System default, do not modify it", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4258), "system" },
                    { 4L, new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4259), "system", true, new Dictionary<string, string>(), "運輸製程", "SPRM_TRANSPORT", "System default, do not modify it", new DateTime(2023, 5, 1, 11, 18, 28, 497, DateTimeKind.Utc).AddTicks(4260), "system" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_attribute_links_attribute_id",
                schema: "sprm",
                table: "attribute_links",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_attribute_links_object_type_id_attribute_id",
                schema: "sprm",
                table: "attribute_links",
                columns: new[] { "object_type_id", "attribute_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_custom_attributes_number",
                schema: "sprm",
                table: "custom_attributes",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_make_types_number",
                schema: "sprm",
                table: "make_types",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_object_types_number",
                schema: "sprm",
                table: "object_types",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_part_usages_used_by_uses",
                schema: "sprm",
                table: "part_usages",
                columns: new[] { "used_by", "uses" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_part_usages_uses",
                schema: "sprm",
                table: "part_usages",
                column: "uses");

            migrationBuilder.CreateIndex(
                name: "IX_part_versions_master_id_version_checkout",
                schema: "sprm",
                table: "part_versions",
                columns: new[] { "master_id", "version", "checkout" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_parts_number_view_type",
                schema: "sprm",
                table: "parts",
                columns: new[] { "number", "view_type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_process_types_number",
                schema: "sprm",
                table: "process_types",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_processes_MakeTypeId",
                schema: "sprm",
                table: "processes",
                column: "MakeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_processes_number",
                schema: "sprm",
                table: "processes",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_processes_process_type_id",
                schema: "sprm",
                table: "processes",
                column: "process_type_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_routing_versions_master_id_version_checkout",
                schema: "sprm",
                table: "routing_versions",
                columns: new[] { "master_id", "version", "checkout" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_routings_part_id_name",
                schema: "sprm",
                table: "routings",
                columns: new[] { "part_id", "name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_users",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "attribute_links",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "part_usages",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "routing_processes",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "custom_attributes",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "object_types",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "part_versions",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "processes",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "routing_versions",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "make_types",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "process_types",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "routings",
                schema: "sprm");

            migrationBuilder.DropTable(
                name: "parts",
                schema: "sprm");
        }
    }
}

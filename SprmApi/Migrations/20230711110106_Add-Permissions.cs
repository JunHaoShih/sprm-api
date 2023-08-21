using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

#nullable disable

namespace SprmApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_admin",
                schema: "sprm",
                table: "app_users",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "是否為系統管理員");

            migrationBuilder.CreateTable(
                name: "permissions",
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
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "App使用者id"),
                    object_type_id = table.Column<long>(type: "bigint", nullable: false, comment: "物件類型id"),
                    create_permitted = table.Column<bool>(type: "boolean", nullable: false, comment: "允許建立"),
                    read_permitted = table.Column<bool>(type: "boolean", nullable: false, comment: "允許讀取"),
                    update_permitted = table.Column<bool>(type: "boolean", nullable: false, comment: "允許修改"),
                    delete_permitted = table.Column<bool>(type: "boolean", nullable: false, comment: "允許刪除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_permissions_app_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "sprm",
                        principalTable: "app_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permissions_object_types_object_type_id",
                        column: x => x.object_type_id,
                        principalSchema: "sprm",
                        principalTable: "object_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "權限");

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1211), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1215) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "make_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1219), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1267), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1267) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1272), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1272) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1274), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1274) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1275), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1275) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1277), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1277) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "object_types",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1279), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1243), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1243) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1246), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1246) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1247), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1247) });

            migrationBuilder.UpdateData(
                schema: "sprm",
                table: "process_types",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "languages", "update_date" },
                values: new object[] { new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1248), new Dictionary<string, string>(), new DateTime(2023, 7, 11, 11, 1, 5, 992, DateTimeKind.Utc).AddTicks(1249) });

            migrationBuilder.CreateIndex(
                name: "IX_permissions_object_type_id",
                schema: "sprm",
                table: "permissions",
                column: "object_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_user_id",
                schema: "sprm",
                table: "permissions",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permissions",
                schema: "sprm");

            migrationBuilder.DropColumn(
                name: "is_admin",
                schema: "sprm",
                table: "app_users");

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
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3303), new DateTime(2023, 7, 6, 7, 57, 37, 360, DateTimeKind.Utc).AddTicks(3303) });

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
    }
}

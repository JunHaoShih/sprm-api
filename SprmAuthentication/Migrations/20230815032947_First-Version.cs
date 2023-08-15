using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SprmAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class FirstVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sprm-auth");

            migrationBuilder.CreateTable(
                name: "app_users",
                schema: "sprm-auth",
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
                    password = table.Column<string>(type: "text", nullable: false, comment: "Password hash"),
                    full_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "App使用者姓名"),
                    is_admin = table.Column<bool>(type: "boolean", nullable: false, comment: "是否為系統管理員"),
                    custom_values = table.Column<JsonDocument>(type: "jsonb", nullable: false, defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()), comment: "自訂屬性值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_users", x => x.id);
                },
                comment: "App使用者");

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "sprm-auth",
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
                        principalSchema: "sprm-auth",
                        principalTable: "app_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "權限");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_user_id_object_type_id",
                schema: "sprm-auth",
                table: "permissions",
                columns: new[] { "user_id", "object_type_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permissions",
                schema: "sprm-auth");

            migrationBuilder.DropTable(
                name: "app_users",
                schema: "sprm-auth");
        }
    }
}

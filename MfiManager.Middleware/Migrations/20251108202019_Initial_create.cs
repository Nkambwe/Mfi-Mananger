using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MfiManager.Middleware.Migrations
{
    /// <inheritdoc />
    public partial class Initial_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TBL_MFI_COMPANY",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    alias = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    reg_number = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    language = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_COMPANY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_ENTITY",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entity_name = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    ip_address = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_ENTITY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_ROLE_GROUP",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    group_description = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    group_scope = table.Column<int>(type: "INT", nullable: false),
                    department = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    is_approved = table.Column<bool>(type: "bit", nullable: true),
                    is_verified = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_ROLE_GROUP", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_USER_ACTIVITY",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activity_name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    system_keyword = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    is_enabled = table.Column<bool>(type: "bit", nullable: false),
                    category = table.Column<int>(type: "INT", nullable: false),
                    is_admin_activity = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_USER_ACTIVITY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_BRANCH",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    branch_code = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    branch_name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    address = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    email_address = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    postal_address = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_BRANCH", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_BRANCH_TBL_MFI_COMPANY_company_id",
                        column: x => x.company_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_COMPANY",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_DEPARTMENT",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    dept_code = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    dept_name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_DEPARTMENT", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_DEPARTMENT_TBL_MFI_COMPANY_company_id",
                        column: x => x.company_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_COMPANY",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_ERROR",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<long>(type: "bigint", nullable: false),
                    error_message = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    error_source = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    error_severity = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    stack_trace = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    error_status = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_ERROR", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_ERROR_TBL_MFI_COMPANY_company_id",
                        column: x => x.company_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_COMPANY",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_ROLE",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_id = table.Column<long>(type: "bigint", nullable: false),
                    role_name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    role_description = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_ROLE", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_ROLE_TBL_MFI_ROLE_GROUP_group_id",
                        column: x => x.group_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_ROLE_GROUP",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_SYS_CONFIG",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parameter_name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    parameter_value = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    param_description = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    company_id = table.Column<long>(type: "bigint", nullable: true),
                    branch_id = table.Column<long>(type: "bigint", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_SYS_CONFIG", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_SYS_CONFIG_TBL_MFI_BRANCH_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_BRANCH",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TBL_MFI_SYS_CONFIG_TBL_MFI_COMPANY_company_id",
                        column: x => x.company_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_COMPANY",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_DEPTUNIT",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_code = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    unit_name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_DEPTUNIT", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_DEPTUNIT_TBL_MFI_DEPARTMENT_department_id",
                        column: x => x.department_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_DEPARTMENT",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_USER",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    first_name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    last_name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    other_name = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    pf_number = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    email_address = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    phone_number = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    password_hash = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    branch_code = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    unit_code = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    is_approved = table.Column<bool>(type: "bit", nullable: true),
                    is_verified = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_locked = table.Column<bool>(type: "bit", nullable: false),
                    is_logged_in = table.Column<bool>(type: "bit", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPasswordChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_USER", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_USER_TBL_MFI_DEPARTMENT_department_id",
                        column: x => x.department_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_DEPARTMENT",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_USER_TBL_MFI_ROLE_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_ROLE",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_ACTIVITY_LOG",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entity_id = table.Column<long>(type: "bigint", nullable: false),
                    ip_address = table.Column<string>(type: "NVARCHAR(80)", nullable: false),
                    action_details = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    activity_id = table.Column<long>(type: "bigint", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_ACTIVITY_LOG", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_ACTIVITY_LOG_TBL_MFI_ENTITY_entity_id",
                        column: x => x.entity_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_ENTITY",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_ACTIVITY_LOG_TBL_MFI_USER_ACTIVITY_activity_id",
                        column: x => x.activity_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_USER_ACTIVITY",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_ACTIVITY_LOG_TBL_MFI_USER_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_USER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_LOGIN_ATTEMPT",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    ip_address = table.Column<string>(type: "NVARCHAR(80)", nullable: false),
                    login_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_successful = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_LOGIN_ATTEMPT", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_LOGIN_ATTEMPT_TBL_MFI_USER_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_USER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MFI_QUICK_ACTION",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    action_label = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    icon_class = table.Column<string>(type: "NVARCHAR(80)", nullable: false),
                    controller = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    action_name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    action_area = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    css_class = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    modified_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "NVARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MFI_QUICK_ACTION", x => x.id);
                    table.ForeignKey(
                        name: "FK_TBL_MFI_QUICK_ACTION_TBL_MFI_USER_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_USER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrefference",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrefference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPrefference_TBL_MFI_USER_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_MFI_USER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_ACTIVITY_LOG_activity_id",
                schema: "dbo",
                table: "TBL_MFI_ACTIVITY_LOG",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_ACTIVITY_LOG_entity_id",
                schema: "dbo",
                table: "TBL_MFI_ACTIVITY_LOG",
                column: "entity_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_ACTIVITY_LOG_user_id",
                schema: "dbo",
                table: "TBL_MFI_ACTIVITY_LOG",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_BRANCH_company_id",
                schema: "dbo",
                table: "TBL_MFI_BRANCH",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_DEPARTMENT_company_id",
                schema: "dbo",
                table: "TBL_MFI_DEPARTMENT",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_DEPTUNIT_department_id",
                schema: "dbo",
                table: "TBL_MFI_DEPTUNIT",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_ERROR_company_id",
                schema: "dbo",
                table: "TBL_MFI_ERROR",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_LOGIN_ATTEMPT_user_id",
                schema: "dbo",
                table: "TBL_MFI_LOGIN_ATTEMPT",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_QUICK_ACTION_user_id",
                schema: "dbo",
                table: "TBL_MFI_QUICK_ACTION",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_ROLE_group_id",
                schema: "dbo",
                table: "TBL_MFI_ROLE",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_SYS_CONFIG_branch_id",
                schema: "dbo",
                table: "TBL_MFI_SYS_CONFIG",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_SYS_CONFIG_company_id",
                schema: "dbo",
                table: "TBL_MFI_SYS_CONFIG",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_USER_department_id",
                schema: "dbo",
                table: "TBL_MFI_USER",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MFI_USER_role_id",
                schema: "dbo",
                table: "TBL_MFI_USER",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrefference_UserId",
                schema: "dbo",
                table: "UserPrefference",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_MFI_ACTIVITY_LOG",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_DEPTUNIT",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_ERROR",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_LOGIN_ATTEMPT",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_QUICK_ACTION",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_SYS_CONFIG",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserPrefference",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_ENTITY",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_USER_ACTIVITY",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_BRANCH",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_USER",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_DEPARTMENT",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_ROLE",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_COMPANY",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_MFI_ROLE_GROUP",
                schema: "dbo");
        }
    }
}

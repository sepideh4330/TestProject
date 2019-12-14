using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DataLayer.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: false),
                    NameFa = table.Column<string>(maxLength: 256, nullable: false),
                    Type = table.Column<short>(nullable: false),
                    Category = table.Column<short>(nullable: false),
                    ReferenceRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Roles_ReferenceRoleId",
                        column: x => x.ReferenceRoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupChangeLogs",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatorIp = table.Column<string>(maxLength: 45, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    OrderRow = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Previous = table.Column<string>(nullable: false),
                    Current = table.Column<string>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChangeLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupRoles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorIdentityId = table.Column<Guid>(nullable: true),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatorIdentityIp = table.Column<string>(maxLength: 45, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 120, nullable: false),
                    Status = table.Column<short>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 450, nullable: true),
                    LastVisitDateTimeOn = table.Column<DateTimeOffset>(nullable: true),
                    LastActivityDateTimeOn = table.Column<DateTimeOffset>(nullable: true),
                    LastLoginDateTimeOn = table.Column<DateTimeOffset>(nullable: true),
                    EmailTokenLifespanDateTimeOn = table.Column<DateTimeOffset>(nullable: true),
                    EmailToken = table.Column<string>(maxLength: 512, nullable: true),
                    CreatorIdentityIp = table.Column<string>(maxLength: 45, nullable: false),
                    CreatorIdentityId = table.Column<Guid>(nullable: true),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatorIdentityId",
                        column: x => x.CreatorIdentityId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorIdentityId = table.Column<Guid>(nullable: true),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatorIdentityIp = table.Column<string>(maxLength: 45, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    GroupCategory = table.Column<short>(nullable: false),
                    GroupType = table.Column<short>(nullable: false),
                    GroupStatus = table.Column<short>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    NameFa = table.Column<string>(maxLength: 120, nullable: false),
                    NameEn = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Users_CreatorIdentityId",
                        column: x => x.CreatorIdentityId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserChangeLogs",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatorIp = table.Column<string>(maxLength: 45, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    OrderRow = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Previous = table.Column<string>(nullable: false),
                    Current = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChangeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChangeLogs_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserChangeLogs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGeolocations",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatorIp = table.Column<string>(maxLength: 45, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Latitude = table.Column<string>(maxLength: 20, nullable: false),
                    Longitude = table.Column<string>(maxLength: 20, nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGeolocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGeolocations_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokenStorages",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorIdentityId = table.Column<Guid>(nullable: true),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatorIdentityIp = table.Column<string>(maxLength: 45, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    AccessTokenHash = table.Column<string>(nullable: true),
                    AccessTokenExpiresDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    RefreshTokenIdHash = table.Column<string>(maxLength: 450, nullable: false),
                    RefreshTokenIdHashSource = table.Column<string>(maxLength: 450, nullable: true),
                    RefreshTokenExpiresDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokenStorages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokenStorages_Users_CreatorIdentityId",
                        column: x => x.CreatorIdentityId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTokenStorages_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUsedPasswords",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorIdentityId = table.Column<Guid>(nullable: true),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatorIdentityIp = table.Column<string>(maxLength: 45, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    HashedPassword = table.Column<string>(maxLength: 450, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUsedPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUsedPasswords_Users_CreatorIdentityId",
                        column: x => x.CreatorIdentityId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserUsedPasswords_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChangeLogs_CreatorId",
                schema: "identity",
                table: "GroupChangeLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChangeLogs_GroupId",
                schema: "identity",
                table: "GroupChangeLogs",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoles_CreatorIdentityId",
                schema: "identity",
                table: "GroupRoles",
                column: "CreatorIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoles_GroupId",
                schema: "identity",
                table: "GroupRoles",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoles_RoleId",
                schema: "identity",
                table: "GroupRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatorIdentityId",
                schema: "identity",
                table: "Groups",
                column: "CreatorIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ReferenceRoleId",
                schema: "identity",
                table: "Roles",
                column: "ReferenceRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChangeLogs_CreatorId",
                schema: "identity",
                table: "UserChangeLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChangeLogs_UserId",
                schema: "identity",
                table: "UserChangeLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeolocations_UserId",
                schema: "identity",
                table: "UserGeolocations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorIdentityId",
                schema: "identity",
                table: "Users",
                column: "CreatorIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                schema: "identity",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokenStorages_CreatorIdentityId",
                schema: "identity",
                table: "UserTokenStorages",
                column: "CreatorIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokenStorages_UserId",
                schema: "identity",
                table: "UserTokenStorages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUsedPasswords_CreatorIdentityId",
                schema: "identity",
                table: "UserUsedPasswords",
                column: "CreatorIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUsedPasswords_UserId",
                schema: "identity",
                table: "UserUsedPasswords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChangeLogs_Users_CreatorId",
                schema: "identity",
                table: "GroupChangeLogs",
                column: "CreatorId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChangeLogs_Groups_GroupId",
                schema: "identity",
                table: "GroupChangeLogs",
                column: "GroupId",
                principalSchema: "identity",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoles_Users_CreatorIdentityId",
                schema: "identity",
                table: "GroupRoles",
                column: "CreatorIdentityId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoles_Groups_GroupId",
                schema: "identity",
                table: "GroupRoles",
                column: "GroupId",
                principalSchema: "identity",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                schema: "identity",
                table: "Users",
                column: "GroupId",
                principalSchema: "identity",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatorIdentityId",
                schema: "identity",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "GroupChangeLogs",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "GroupRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserChangeLogs",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserGeolocations",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserTokenStorages",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserUsedPasswords",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "identity");
        }
    }
}

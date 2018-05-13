using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lgm.Emos.Infrastructure.Migrations
{
    public partial class add_user_related_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_ParentEntityEntityId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_User_UserId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Team_TeamLeaderTeamId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_UserId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEntity_User_UserId",
                table: "UserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeam_User_UserId",
                table: "UserTeam");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserEntity_UserId",
                table: "UserEntity");

            migrationBuilder.DropIndex(
                name: "IX_Team_TeamLeaderTeamId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Entity_ParentEntityEntityId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserTeam");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "TeamLeaderTeamId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ParentEntityEntityId",
                table: "Entity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserEntity",
                newName: "EmosUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Team",
                newName: "TeamLeaderId");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Team",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Team_UserId",
                table: "Team",
                newName: "IX_Team_TeamLeaderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Entity",
                newName: "ParentEntityId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Entity",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Entity_UserId",
                table: "Entity",
                newName: "IX_Entity_ParentEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                columns: new[] { "EntityId", "EmosUserId" });

            migrationBuilder.CreateTable(
                name: "IdentityAppUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityAppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmosUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardCode = table.Column<string>(nullable: true),
                    CardId = table.Column<int>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    FunctionId = table.Column<int>(nullable: true),
                    GradeId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmosUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmosUser_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmosUser_Function_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Function",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmosUser_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmosUser_ApplicationGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmosUser_IdentityAppUser_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "IdentityAppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmosUser_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_EmosUserId",
                table: "UserEntity",
                column: "EmosUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmosUser_CardId",
                table: "EmosUser",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_EmosUser_FunctionId",
                table: "EmosUser",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmosUser_GradeId",
                table: "EmosUser",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmosUser_GroupId",
                table: "EmosUser",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EmosUser_IdentityId",
                table: "EmosUser",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmosUser_TeamId",
                table: "EmosUser",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_ParentEntityId",
                table: "Entity",
                column: "ParentEntityId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Team_TeamLeaderId",
                table: "Team",
                column: "TeamLeaderId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntity_EmosUser_EmosUserId",
                table: "UserEntity",
                column: "EmosUserId",
                principalTable: "EmosUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeam_EmosUser_UserId",
                table: "UserTeam",
                column: "UserId",
                principalTable: "EmosUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_ParentEntityId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Team_TeamLeaderId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEntity_EmosUser_EmosUserId",
                table: "UserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeam_EmosUser_UserId",
                table: "UserTeam");

            migrationBuilder.DropTable(
                name: "EmosUser");

            migrationBuilder.DropTable(
                name: "IdentityAppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserEntity_EmosUserId",
                table: "UserEntity");

            migrationBuilder.RenameColumn(
                name: "EmosUserId",
                table: "UserEntity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TeamLeaderId",
                table: "Team",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Team",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_TeamLeaderId",
                table: "Team",
                newName: "IX_Team_UserId");

            migrationBuilder.RenameColumn(
                name: "ParentEntityId",
                table: "Entity",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Entity",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Entity_ParentEntityId",
                table: "Entity",
                newName: "IX_Entity_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserTeam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserEntity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamLeaderTeamId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentEntityEntityId",
                table: "Entity",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                columns: new[] { "EntityId", "UserId" });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardCode = table.Column<string>(nullable: true),
                    CardId = table.Column<int>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(maxLength: 50, nullable: false),
                    EntityId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    FunctionId = table.Column<int>(nullable: true),
                    GradeId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    IdPicture = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Number = table.Column<string>(maxLength: 50, nullable: false),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Function_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Function",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ApplicationGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_UserId",
                table: "UserEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamLeaderTeamId",
                table: "Team",
                column: "TeamLeaderTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ParentEntityEntityId",
                table: "Entity",
                column: "ParentEntityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CardId",
                table: "User",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_User_EntityId",
                table: "User",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FunctionId",
                table: "User",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GradeId",
                table: "User",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupId",
                table: "User",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TeamId",
                table: "User",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_ParentEntityEntityId",
                table: "Entity",
                column: "ParentEntityEntityId",
                principalTable: "Entity",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_User_UserId",
                table: "Entity",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Team_TeamLeaderTeamId",
                table: "Team",
                column: "TeamLeaderTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_UserId",
                table: "Team",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntity_User_UserId",
                table: "UserEntity",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeam_User_UserId",
                table: "UserTeam",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

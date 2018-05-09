using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lgm.Emos.Infrastructure.Migrations
{
    public partial class add_user_related_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tools",
                table: "Tools");

            migrationBuilder.RenameTable(
                name: "Tools",
                newName: "Tool");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tool",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ref",
                table: "Tool",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tool",
                table: "Tool",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalInfo = table.Column<string>(maxLength: 50, nullable: false),
                    CardTypeId = table.Column<int>(maxLength: 50, nullable: false),
                    DateCreation = table.Column<DateTime>(maxLength: 50, nullable: false),
                    DateExpiration = table.Column<DateTime>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Number = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPicture = table.Column<int>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Rank = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

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
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentEntityEntityId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    idPicture = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_ParentEntityEntityId",
                        column: x => x.ParentEntityEntityId,
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplyScheduleAccessRule = table.Column<bool>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    EntityId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TeamLeaderTeamId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Team_TeamLeaderTeamId",
                        column: x => x.TeamLeaderTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => new { x.EntityId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserEntity_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEntity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeam",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeam", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeam_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ParentEntityEntityId",
                table: "Entity",
                column: "ParentEntityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_UserId",
                table: "Entity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_EntityId",
                table: "Team",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamLeaderTeamId",
                table: "Team",
                column: "TeamLeaderTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserId",
                table: "Team",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_UserId",
                table: "UserEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeam_UserId",
                table: "UserTeam",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Entity_EntityId",
                table: "User",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Team_TeamId",
                table: "User",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_User_UserId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_UserId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropTable(
                name: "UserTeam");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "ApplicationGroup");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tool",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "Ref",
                table: "Tool");

            migrationBuilder.RenameTable(
                name: "Tool",
                newName: "Tools");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tools",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tools",
                table: "Tools",
                column: "Id");
        }
    }
}

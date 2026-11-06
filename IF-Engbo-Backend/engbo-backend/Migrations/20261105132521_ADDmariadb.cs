using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace engbo_backend.Migrations
{
    /// <inheritdoc />
    public partial class ADDmariadb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AktivitetsKategorier",
                columns: table => new
                {
                    AktivitetsKategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AktivitetsType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivitetsKategorier", x => x.AktivitetsKategoriId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BaneTyper",
                columns: table => new
                {
                    BaneTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Banetype = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaneTyper", x => x.BaneTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hold",
                columns: table => new
                {
                    HoldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HoldNavn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hold", x => x.HoldId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    RolleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RolleNavn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RolleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aktiviteter",
                columns: table => new
                {
                    AktivitetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AktivitetsKategoriId = table.Column<int>(type: "int", nullable: false),
                    HoldId = table.Column<int>(type: "int", nullable: false),
                    Modstander = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dato = table.Column<DateOnly>(type: "date", nullable: false),
                    Tid = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    Varighed = table.Column<int>(type: "int", nullable: false),
                    BaneTypeId = table.Column<int>(type: "int", nullable: false),
                    Bane = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktiviteter", x => x.AktivitetId);
                    table.ForeignKey(
                        name: "FK_Aktiviteter_AktivitetsKategorier_AktivitetsKategoriId",
                        column: x => x.AktivitetsKategoriId,
                        principalTable: "AktivitetsKategorier",
                        principalColumn: "AktivitetsKategoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aktiviteter_BaneTyper_BaneTypeId",
                        column: x => x.BaneTypeId,
                        principalTable: "BaneTyper",
                        principalColumn: "BaneTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aktiviteter_Hold_HoldId",
                        column: x => x.HoldId,
                        principalTable: "Hold",
                        principalColumn: "HoldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aktiviteter_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fremmoede",
                columns: table => new
                {
                    FremmoedeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AktivitetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fremmoede", x => x.FremmoedeId);
                    table.ForeignKey(
                        name: "FK_Fremmoede_Aktiviteter_AktivitetId",
                        column: x => x.AktivitetId,
                        principalTable: "Aktiviteter",
                        principalColumn: "AktivitetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fremmoede_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KampResultater",
                columns: table => new
                {
                    KampResultatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AktivitetId = table.Column<int>(type: "int", nullable: false),
                    HjemmeholdMaal = table.Column<int>(type: "int", nullable: false),
                    UdeholdMaal = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KampResultater", x => x.KampResultatId);
                    table.ForeignKey(
                        name: "FK_KampResultater_Aktiviteter_AktivitetId",
                        column: x => x.AktivitetId,
                        principalTable: "Aktiviteter",
                        principalColumn: "AktivitetId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tilmeldinger",
                columns: table => new
                {
                    TilmeldingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AktivitetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Kommentar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilmeldinger", x => x.TilmeldingId);
                    table.ForeignKey(
                        name: "FK_Tilmeldinger_Aktiviteter_AktivitetId",
                        column: x => x.AktivitetId,
                        principalTable: "Aktiviteter",
                        principalColumn: "AktivitetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tilmeldinger_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Aktiviteter_AktivitetsKategoriId",
                table: "Aktiviteter",
                column: "AktivitetsKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Aktiviteter_BaneTypeId",
                table: "Aktiviteter",
                column: "BaneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Aktiviteter_HoldId",
                table: "Aktiviteter",
                column: "HoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Aktiviteter_UserId",
                table: "Aktiviteter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fremmoede_AktivitetId",
                table: "Fremmoede",
                column: "AktivitetId");

            migrationBuilder.CreateIndex(
                name: "IX_Fremmoede_UserId",
                table: "Fremmoede",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_KampResultater_AktivitetId",
                table: "KampResultater",
                column: "AktivitetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilmeldinger_AktivitetId",
                table: "Tilmeldinger",
                column: "AktivitetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilmeldinger_UserId",
                table: "Tilmeldinger",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fremmoede");

            migrationBuilder.DropTable(
                name: "KampResultater");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Tilmeldinger");

            migrationBuilder.DropTable(
                name: "Aktiviteter");

            migrationBuilder.DropTable(
                name: "AktivitetsKategorier");

            migrationBuilder.DropTable(
                name: "BaneTyper");

            migrationBuilder.DropTable(
                name: "Hold");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "addresstype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contacttype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contractstatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personcategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persontype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "workshifts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shiftStartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    shiftEndTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_idCountry",
                        column: x => x.fkIdCountry,
                        principalTable: "country",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "town",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdDepartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_idDepartment",
                        column: x => x.fkIdDepartment,
                        principalTable: "department",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idperson = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fkIdPersonType = table.Column<int>(type: "int", nullable: false),
                    fkIdPersonCate = table.Column<int>(type: "int", nullable: false),
                    fkIdTown = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_idPersonCate",
                        column: x => x.fkIdPersonCate,
                        principalTable: "personcategory",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_idPersonType",
                        column: x => x.fkIdPersonType,
                        principalTable: "persontype",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_idTown",
                        column: x => x.fkIdTown,
                        principalTable: "town",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdPerson = table.Column<int>(type: "int", nullable: false),
                    fkIdAddressType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_idAddressType",
                        column: x => x.fkIdAddressType,
                        principalTable: "addresstype",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_idEmployee",
                        column: x => x.fkIdPerson,
                        principalTable: "person",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    contractStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    contractEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fkIdClient = table.Column<int>(type: "int", nullable: false),
                    fkIdEmployee = table.Column<int>(type: "int", nullable: false),
                    fkIdContractStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_idClientContract",
                        column: x => x.fkIdClient,
                        principalTable: "person",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_idContractStatus",
                        column: x => x.fkIdContractStatus,
                        principalTable: "contractstatus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_idEmployeeContract",
                        column: x => x.fkIdEmployee,
                        principalTable: "person",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personcontact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdPerson = table.Column<int>(type: "int", nullable: false),
                    fkIdContactType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_idContactType",
                        column: x => x.fkIdContactType,
                        principalTable: "contacttype",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_idPersonCont",
                        column: x => x.fkIdPerson,
                        principalTable: "person",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shiftscheduling",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fkIdContract = table.Column<int>(type: "int", nullable: false),
                    fkIdPerson = table.Column<int>(type: "int", nullable: false),
                    fkIdWorkShifts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_idContract",
                        column: x => x.fkIdContract,
                        principalTable: "contract",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_idEmploShiftSche",
                        column: x => x.fkIdPerson,
                        principalTable: "person",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_idWorkShifts",
                        column: x => x.fkIdWorkShifts,
                        principalTable: "workshifts",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk_idAddressType",
                table: "address",
                column: "fkIdAddressType");

            migrationBuilder.CreateIndex(
                name: "fk_idEmployee",
                table: "address",
                column: "fkIdPerson");

            migrationBuilder.CreateIndex(
                name: "fk_idClientContract",
                table: "contract",
                column: "fkIdClient");

            migrationBuilder.CreateIndex(
                name: "fk_idContractStatus",
                table: "contract",
                column: "fkIdContractStatus");

            migrationBuilder.CreateIndex(
                name: "fk_idEmployeeContract",
                table: "contract",
                column: "fkIdEmployee");

            migrationBuilder.CreateIndex(
                name: "name",
                table: "country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_idCountry",
                table: "department",
                column: "fkIdCountry");

            migrationBuilder.CreateIndex(
                name: "fk_idPersonCate",
                table: "person",
                column: "fkIdPersonCate");

            migrationBuilder.CreateIndex(
                name: "fk_idPersonType",
                table: "person",
                column: "fkIdPersonType");

            migrationBuilder.CreateIndex(
                name: "fk_idTown",
                table: "person",
                column: "fkIdTown");

            migrationBuilder.CreateIndex(
                name: "idperson",
                table: "person",
                column: "idperson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_idContactType",
                table: "personcontact",
                column: "fkIdContactType");

            migrationBuilder.CreateIndex(
                name: "fk_idPersonCont",
                table: "personcontact",
                column: "fkIdPerson");

            migrationBuilder.CreateIndex(
                name: "fk_idContract",
                table: "shiftscheduling",
                column: "fkIdContract");

            migrationBuilder.CreateIndex(
                name: "fk_idEmploShiftSche",
                table: "shiftscheduling",
                column: "fkIdPerson");

            migrationBuilder.CreateIndex(
                name: "fk_idWorkShifts",
                table: "shiftscheduling",
                column: "fkIdWorkShifts");

            migrationBuilder.CreateIndex(
                name: "fk_idDepartment",
                table: "town",
                column: "fkIdDepartment"); */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "personcontact");

            migrationBuilder.DropTable(
                name: "shiftscheduling");

            migrationBuilder.DropTable(
                name: "addresstype");

            migrationBuilder.DropTable(
                name: "contacttype");

            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "workshifts");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "contractstatus");

            migrationBuilder.DropTable(
                name: "personcategory");

            migrationBuilder.DropTable(
                name: "persontype");

            migrationBuilder.DropTable(
                name: "town");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "country"); */
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Polyclinic.DAL.Implementation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    CabinetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CabinetNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.CabinetId);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    DiagnosisId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.DiagnosisId);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialtyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    BornDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PassportData = table.Column<string>(type: "text", nullable: true),
                    Snills = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    LicenseNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Policy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinetInfos",
                columns: table => new
                {
                    CabinetInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CabinetId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinetInfos", x => x.CabinetInfoId);
                    table.ForeignKey(
                        name: "FK_CabinetInfos_Cabinets_CabinetId",
                        column: x => x.CabinetId,
                        principalTable: "Cabinets",
                        principalColumn: "CabinetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinetInfos_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisInfos",
                columns: table => new
                {
                    DiagnosisInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DiagnosisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisInfos", x => x.DiagnosisInfoId);
                    table.ForeignKey(
                        name: "FK_DiagnosisInfos_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosisInfos_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    DateVisit = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Complaint = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visit_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cabinets",
                columns: new[] { "CabinetId", "CabinetNumber", "Description" },
                values: new object[,]
                {
                    { 1, 228, null },
                    { 2, 320, null },
                    { 3, 223, null }
                });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "DiagnosisId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Needs careful treatment", "Diabetes" },
                    { 2, "Nothing serious, just avoid much coffee", "Tachycardia" },
                    { 3, "Outflow of blood from the head is disturbed", "Headache" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "SpecialtyId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Endocrinologist" },
                    { 2, null, "Сardiologist" },
                    { 3, null, "Therapist" },
                    { 4, null, "Neurologist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BornDate", "Name", "PassportData", "Snills", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrey", "2020445765", "1234", "Solovyev" },
                    { 2, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vasiliy", "2020123987", "2345", "Sychev" },
                    { 3, new DateTime(2000, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "2020234765", "3456", "Tkachenko" },
                    { 4, new DateTime(2001, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "2014456765", "4567", "Menshih" },
                    { 5, new DateTime(2000, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lev", "2020567123", "6789", "Makeev" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "LicenseNumber", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { 1, "1111", 1, 1 },
                    { 2, "2222", 2, 2 },
                    { 3, "3333", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Policy", "UserId" },
                values: new object[,]
                {
                    { 1, "12321", 4 },
                    { 2, "213214", 5 }
                });

            migrationBuilder.InsertData(
                table: "CabinetInfos",
                columns: new[] { "CabinetInfoId", "CabinetId", "DateEnd", "DateStart", "DoctorId" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, null, new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 2, null, new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "DiagnosisInfos",
                columns: new[] { "DiagnosisInfoId", "DiagnosisId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Visit",
                columns: new[] { "VisitId", "Complaint", "DateVisit", "DoctorId", "PatientId", "Price" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1300.0 },
                    { 2, "Too expensive", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1000.0 },
                    { 3, null, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1200.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabinetInfos_CabinetId",
                table: "CabinetInfos",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinetInfos_DoctorId",
                table: "CabinetInfos",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisInfos_DiagnosisId",
                table: "DiagnosisInfos",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisInfos_PatientId",
                table: "DiagnosisInfos",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_DoctorId",
                table: "Visit",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinetInfos");

            migrationBuilder.DropTable(
                name: "DiagnosisInfos");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

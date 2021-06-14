using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Polyclinic.DAL.Implementation.Migrations
{
    public partial class AddMoreSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "Policy",
                value: "123216");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BornDate", "Name", "PassportData", "Snills", "Surname" },
                values: new object[,]
                {
                    { 6, new DateTime(1989, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrey", "2342343562", "8543", "Kartashov" },
                    { 7, new DateTime(1995, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kirill", "0934765194", "1029", "Mikhaylov" },
                    { 8, new DateTime(1998, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexey", "1241241897", "9823", "Tereshkov" },
                    { 9, new DateTime(1993, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vitaliy", "0375913498", "9012", "Lobanov" },
                    { 10, new DateTime(1999, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruslan", "4012783409", "1872", "Mayboroda" },
                    { 11, new DateTime(1990, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikolay", "7812093476", "1047", "Kondusov" },
                    { 12, new DateTime(2000, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikhail", "9012456512", "1045", "Miclayev" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "LicenseNumber", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { 4, "4444", 4, 6 },
                    { 5, "5555", 1, 7 },
                    { 6, "6666", 2, 8 },
                    { 7, "7777", 3, 9 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Policy", "UserId" },
                values: new object[,]
                {
                    { 3, "091234", 10 },
                    { 4, "561209", 11 },
                    { 5, "048130", 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "Policy",
                value: "12321");
        }
    }
}

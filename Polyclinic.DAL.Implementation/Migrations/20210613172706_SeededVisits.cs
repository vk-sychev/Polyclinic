using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Polyclinic.DAL.Implementation.Migrations
{
    public partial class SeededVisits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "DateVisit",
                value: new DateTime(2021, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                columns: new[] { "Complaint", "DateVisit" },
                values: new object[] { "Have a headache", new DateTime(2021, 7, 20, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "DateVisit",
                value: new DateTime(2021, 6, 25, 15, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "VisitId", "Complaint", "DateVisit", "DoctorId", "PatientId", "Price" },
                values: new object[,]
                {
                    { 24, null, new DateTime(2021, 7, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, 1200.0 },
                    { 23, null, new DateTime(2021, 7, 26, 11, 45, 0, 0, DateTimeKind.Unspecified), 7, 4, 1200.0 },
                    { 22, null, new DateTime(2021, 7, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 1200.0 },
                    { 21, null, new DateTime(2021, 5, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, 1200.0 },
                    { 20, null, new DateTime(2021, 5, 6, 11, 45, 0, 0, DateTimeKind.Unspecified), 5, 4, 1200.0 },
                    { 19, null, new DateTime(2021, 5, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 1200.0 },
                    { 18, null, new DateTime(2021, 5, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 4, 1200.0 },
                    { 17, null, new DateTime(2021, 5, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1200.0 },
                    { 16, "Have a headache", new DateTime(2021, 5, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1000.0 },
                    { 15, null, new DateTime(2021, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1300.0 },
                    { 13, null, new DateTime(2021, 5, 6, 11, 45, 0, 0, DateTimeKind.Unspecified), 5, 4, 1200.0 },
                    { 12, null, new DateTime(2021, 5, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 1200.0 },
                    { 11, null, new DateTime(2021, 5, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 4, 1200.0 },
                    { 10, null, new DateTime(2021, 5, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1200.0 },
                    { 9, "Have a headache", new DateTime(2021, 5, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1000.0 },
                    { 8, null, new DateTime(2021, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1300.0 },
                    { 7, null, new DateTime(2021, 6, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 1200.0 },
                    { 6, null, new DateTime(2021, 6, 26, 11, 45, 0, 0, DateTimeKind.Unspecified), 5, 4, 1200.0 },
                    { 5, null, new DateTime(2021, 6, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 1200.0 },
                    { 14, null, new DateTime(2021, 5, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 1200.0 },
                    { 4, null, new DateTime(2021, 6, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 4, 1200.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 1,
                column: "DateVisit",
                value: new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 2,
                columns: new[] { "Complaint", "DateVisit" },
                values: new object[] { "Too expensive", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Visits",
                keyColumn: "VisitId",
                keyValue: 3,
                column: "DateVisit",
                value: new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

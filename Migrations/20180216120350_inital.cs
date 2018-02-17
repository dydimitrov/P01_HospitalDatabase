using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace P01_HospitalDatabase.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    MedicamentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.MedicamentID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    DiagnoseId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HasInsurance = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PatientMedicamentId = table.Column<int>(nullable: false),
                    PatientMedicamentsMedicamentId = table.Column<int>(nullable: true),
                    PatientMedicamentsPatientId = table.Column<int>(nullable: true),
                    VisitationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    DiagnoseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.DiagnoseID);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Patients",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false),
                    MedicamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => new { x.PatientId, x.MedicamentId });
                    table.ForeignKey(
                        name: "FK_PatientMedicament_Medicaments",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "MedicamentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientMedicament_Patients",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visitations",
                columns: table => new
                {
                    VisitationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(maxLength: 250, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitations", x => x.VisitationID);
                    table.ForeignKey(
                        name: "FK_Visitations_Patients",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Specialty = table.Column<string>(maxLength: 100, nullable: true),
                    VisitationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Visitations_VisitationId",
                        column: x => x.VisitationId,
                        principalTable: "Visitations",
                        principalColumn: "VisitationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VisitationId",
                table: "Doctors",
                column: "VisitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiagnoseId",
                table: "Patients",
                column: "DiagnoseId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_VisitationId",
                table: "Patients",
                column: "VisitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientMedicamentsPatientId_PatientMedicamentsMedicamentId",
                table: "Patients",
                columns: new[] { "PatientMedicamentsPatientId", "PatientMedicamentsMedicamentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicamentId",
                table: "Prescriptions",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitations_DoctorId",
                table: "Visitations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitations_PatientId",
                table: "Visitations",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Visitations_VisitationId",
                table: "Patients",
                column: "VisitationId",
                principalTable: "Visitations",
                principalColumn: "VisitationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diagnoses_DiagnoseId",
                table: "Patients",
                column: "DiagnoseId",
                principalTable: "Diagnoses",
                principalColumn: "DiagnoseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Prescriptions_PatientMedicamentsPatientId_PatientMedicamentsMedicamentId",
                table: "Patients",
                columns: new[] { "PatientMedicamentsPatientId", "PatientMedicamentsMedicamentId" },
                principalTable: "Prescriptions",
                principalColumns: new[] { "PatientId", "MedicamentId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitations_Doctors",
                table: "Visitations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicament_Patients",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitations_Patients",
                table: "Visitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Visitations_VisitationId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Visitations");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}

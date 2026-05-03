using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace schoolApi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Cpf = table.Column<string>(type: "longtext", nullable: false),
                    Age = table.Column<int>(type: "INT NOT NULL", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Cpf = table.Column<string>(type: "longtext", nullable: false),
                    Age = table.Column<int>(type: "INT NOT NULL", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubjectMatter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectMatter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectMatter_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassroomSubjectMatter",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    SubjectMatterId = table.Column<int>(type: "int", nullable: false),
                    Register = table.Column<Guid>(type: "char(36)", nullable: false),
                    Day = table.Column<string>(type: "ENUM('Monday', 'Tuesday', 'Wednesday', 'Thusday', 'Friday', 'Saturday', 'Sunday', 'Undefined') DEFAULT 'Undefined'", nullable: false),
                    StartedAt = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    EndedAt = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomSubjectMatter", x => new { x.ClassroomId, x.SubjectMatterId });
                    table.ForeignKey(
                        name: "FK_ClassroomSubjectMatter_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomSubjectMatter_SubjectMatter_SubjectMatterId",
                        column: x => x.SubjectMatterId,
                        principalTable: "SubjectMatter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseSubjectMatter",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SubjectMatterId = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<sbyte>(type: "TINYINT(1) NOT NULL DEFAULT 0", nullable: false),
                    WorkloadHours = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<sbyte>(type: "TINYINT(1) NOT NULL DEFAULT 0", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubjectMatter", x => new { x.CourseId, x.SubjectMatterId });
                    table.ForeignKey(
                        name: "FK_CourseSubjectMatter_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubjectMatter_SubjectMatter_SubjectMatterId",
                        column: x => x.SubjectMatterId,
                        principalTable: "SubjectMatter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentSubjectMatter",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectMatterId = table.Column<int>(type: "int", nullable: false),
                    Register = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstGrade = table.Column<decimal>(type: "DECIMAL(4,2)", nullable: false),
                    SecondGrade = table.Column<decimal>(type: "DECIMAL(4,2)", nullable: false),
                    GradeTotal = table.Column<decimal>(type: "DECIMAL(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectMatter", x => new { x.StudentId, x.SubjectMatterId });
                    table.ForeignKey(
                        name: "FK_StudentSubjectMatter_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjectMatter_SubjectMatter_SubjectMatterId",
                        column: x => x.SubjectMatterId,
                        principalTable: "SubjectMatter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomSubjectMatter_SubjectMatterId",
                table: "ClassroomSubjectMatter",
                column: "SubjectMatterId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjectMatter_SubjectMatterId",
                table: "CourseSubjectMatter",
                column: "SubjectMatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectMatter_SubjectMatterId",
                table: "StudentSubjectMatter",
                column: "SubjectMatterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectMatter_TeacherId",
                table: "SubjectMatter",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassroomSubjectMatter");

            migrationBuilder.DropTable(
                name: "CourseSubjectMatter");

            migrationBuilder.DropTable(
                name: "StudentSubjectMatter");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "SubjectMatter");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}

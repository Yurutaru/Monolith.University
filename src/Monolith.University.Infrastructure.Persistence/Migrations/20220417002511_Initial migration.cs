using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Monolith.University.Infrastructure.Persistence.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:education_form", "day,evening")
                .Annotation("Npgsql:Enum:person_discriminator", "student,teacher")
                .Annotation("Npgsql:Enum:ticket_status", "open,accepted,closed");

            migrationBuilder.CreateTable(
                name: "TFaculty",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TFacuiltyId", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TPerson",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    discriminator = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    MiddleName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    bio = table.Column<string>(type: "text", nullable: true),
                    date_of_birthday = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPerson", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TCourse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    faculty_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TCourseId", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_course_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "TFaculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TDepartment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    faculty_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TDepartmentId", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_department_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "TFaculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TSpecialization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    duration = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: false),
                    faculty_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TSpecializationId", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_specialization_t_faculty_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "TFaculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TGroup",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    faculty_id = table.Column<long>(type: "bigint", nullable: false),
                    course_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TGroupId", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_group_t_course_course_id",
                        column: x => x.course_id,
                        principalTable: "TCourse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_group_t_faculty_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "TFaculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTeacher",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    faculty_id = table.Column<long>(type: "bigint", nullable: false),
                    department_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTeacher", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_teacher_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "TDepartment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_teacher_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "TFaculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_teacher_t_person_id",
                        column: x => x.id,
                        principalTable: "TPerson",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TStudent",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    faculty_id = table.Column<long>(type: "bigint", nullable: false),
                    course_id = table.Column<long>(type: "bigint", nullable: false),
                    group_id = table.Column<long>(type: "bigint", nullable: false),
                    specialization_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TStudent", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_student_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "TCourse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_student_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "TFaculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_student_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "TGroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_student_specialization_specialization_id",
                        column: x => x.specialization_id,
                        principalTable: "TSpecialization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_student_t_person_id",
                        column: x => x.id,
                        principalTable: "TPerson",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTeacherCard",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    MiddleName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    teacher_id = table.Column<long>(type: "bigint", nullable: false),
                    faculty_id = table.Column<long>(type: "bigint", nullable: false),
                    department_id = table.Column<long>(type: "bigint", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_teacher_card", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_teacher_card_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "TDepartment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_teacher_card_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "TFaculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_teacher_card_t_person_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "TTeacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TStudentCard",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    MiddleName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    student_id = table.Column<long>(type: "bigint", nullable: false),
                    faculty_id = table.Column<long>(type: "bigint", nullable: false),
                    education_form = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_student_card", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_student_card_faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "TFaculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_student_card_t_person_student_id",
                        column: x => x.student_id,
                        principalTable: "TStudent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTicket",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Body = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: true),
                    ticket_status = table.Column<int>(type: "integer", nullable: false),
                    student_id = table.Column<long>(type: "bigint", nullable: false),
                    teacher_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TicketId", x => x.id);
                    table.ForeignKey(
                        name: "fk_t_ticket_t_student_student_id",
                        column: x => x.student_id,
                        principalTable: "TStudent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_ticket_t_teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "TTeacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_t_course_faculty_id",
                table: "TCourse",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_department_faculty_id",
                table: "TDepartment",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_group_course_id",
                table: "TGroup",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_group_faculty_id",
                table: "TGroup",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_specialization_faculty_id",
                table: "TSpecialization",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_student_course_id",
                table: "TStudent",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_student_faculty_id",
                table: "TStudent",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_student_group_id",
                table: "TStudent",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_student_specialization_id",
                table: "TStudent",
                column: "specialization_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_student_card_faculty_id",
                table: "TStudentCard",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_student_card_student_id",
                table: "TStudentCard",
                column: "student_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_t_teacher_department_id",
                table: "TTeacher",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_teacher_faculty_id",
                table: "TTeacher",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_teacher_card_department_id",
                table: "TTeacherCard",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_teacher_card_faculty_id",
                table: "TTeacherCard",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_teacher_card_teacher_id",
                table: "TTeacherCard",
                column: "teacher_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_t_ticket_student_id",
                table: "TTicket",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_t_ticket_teacher_id",
                table: "TTicket",
                column: "teacher_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TStudentCard");

            migrationBuilder.DropTable(
                name: "TTeacherCard");

            migrationBuilder.DropTable(
                name: "TTicket");

            migrationBuilder.DropTable(
                name: "TStudent");

            migrationBuilder.DropTable(
                name: "TTeacher");

            migrationBuilder.DropTable(
                name: "TGroup");

            migrationBuilder.DropTable(
                name: "TSpecialization");

            migrationBuilder.DropTable(
                name: "TDepartment");

            migrationBuilder.DropTable(
                name: "TPerson");

            migrationBuilder.DropTable(
                name: "TCourse");

            migrationBuilder.DropTable(
                name: "TFaculty");
        }
    }
}

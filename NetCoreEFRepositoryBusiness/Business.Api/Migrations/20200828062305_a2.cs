using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Api.Migrations
{
    public partial class a2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseTest3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTest3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Followers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeTest2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeTest2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeopleTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTest3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false),
                    Roll = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Class = table.Column<int>(nullable: false),
                    Section = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTest2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GradeTest2Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTest2s_GradeTest2s_GradeTest2Id",
                        column: x => x.GradeTest2Id,
                        principalTable: "GradeTest2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumeDetailTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumeType = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    PeopleTestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumeDetailTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumeDetailTests_PeopleTests_PeopleTestId",
                        column: x => x.PeopleTestId,
                        principalTable: "PeopleTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse3",
                columns: table => new
                {
                    StudentTest3Id = table.Column<int>(nullable: false),
                    CourseTest3Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse3", x => new { x.StudentTest3Id, x.CourseTest3Id });
                    table.ForeignKey(
                        name: "FK_StudentCourse3_CourseTest3_CourseTest3Id",
                        column: x => x.CourseTest3Id,
                        principalTable: "CourseTest3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse3_StudentTest3_StudentTest3Id",
                        column: x => x.StudentTest3Id,
                        principalTable: "StudentTest3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumeDetailTests_PeopleTestId",
                table: "ConsumeDetailTests",
                column: "PeopleTestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse3_CourseTest3Id",
                table: "StudentCourse3",
                column: "CourseTest3Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest2s_GradeTest2Id",
                table: "StudentTest2s",
                column: "GradeTest2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumeDetailTests");

            migrationBuilder.DropTable(
                name: "DeveloperTests");

            migrationBuilder.DropTable(
                name: "StudentCourse3");

            migrationBuilder.DropTable(
                name: "StudentTest2s");

            migrationBuilder.DropTable(
                name: "StudentTests");

            migrationBuilder.DropTable(
                name: "PeopleTests");

            migrationBuilder.DropTable(
                name: "CourseTest3");

            migrationBuilder.DropTable(
                name: "StudentTest3");

            migrationBuilder.DropTable(
                name: "GradeTest2s");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONLINE_EXAM_FCI.Migrations
{
    /// <inheritdoc />
    public partial class am1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "PasswordConfirmed", "RoleID", "UserName", "photo" },
                values: new object[] { 2, "Doctor@gmail.com", "72f4be89d6ebab1496e21e38bcd7c8ca0a68928af3081ad7dff87e772eb350c2", "72f4be89d6ebab1496e21e38bcd7c8ca0a68928af3081ad7dff87e772eb350c2", 0, "Doctor", "student-photo-url" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

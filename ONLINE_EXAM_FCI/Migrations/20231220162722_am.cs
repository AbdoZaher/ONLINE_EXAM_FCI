using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONLINE_EXAM_FCI.Migrations
{
    /// <inheritdoc />
    public partial class am : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleID",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleID",
                value: 1);
        }
    }
}

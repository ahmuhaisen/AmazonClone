using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AssignAllRolesToTheFirstAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("\r\n\r\nINSERT INTO [security].[UserRoles] (UserId, RoleId) SELECT '7eb0eec1-0a6e-4f05-8dff-1c11d52ed535', Id FROM [security].[Roles]");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId = '7eb0eec1-0a6e-4f05-8dff-1c11d52ed535'");

        }
    }
}

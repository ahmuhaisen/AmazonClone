using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePictureUrl]) VALUES
                    (N'7eb0eec1-0a6e-4f05-8dff-1c11d52ed535', N'sameer_admin', N'SAMEER_ADMIN', N'sameer_admin@koko.com', N'SAMEER_ADMIN@KOKO.COM', 0, N'AQAAAAIAAYagAAAAENlZLb7MWOrvhNJzgUxCe1iIqLME4NpmhWaC5ZvjOcOhnJyd4TTi2/4+pWbcDTJ8yQ==', N'TM64X3EL3L5KURUE2AYYBRAVHSAWPE5J', N'56de6fe4-a535-4020-a7ea-1c5d6a04ecf1', NULL, 0, 0, NULL, 1, 0, N'Sameer', N'AbuAlNil', NULL)"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM [security].[Users] WHERE Id = '7eb0eec1-0a6e-4f05-8dff-1c11d52ed535'"
                );
        }
    }
}

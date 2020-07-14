using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCard.Migrations
{
    public partial class sp_GetBadgeByName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storedProcedure = @"CREATE PROCEDURE sp_GetBadgeByName 
                                    @name varchar(50)
                                    AS
                                    BEGIN
                                    SELECT * FROM dbo.Badges WHERE Name = @name
                                    END;";

            migrationBuilder.Sql(storedProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

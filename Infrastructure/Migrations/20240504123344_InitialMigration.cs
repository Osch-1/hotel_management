using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up( MigrationBuilder migrationBuilder )
    {
        migrationBuilder.CreateTable(
            name: "Hotel",
            columns: table => new
            {
                Id = table.Column<int>( type: "int", nullable: false )
                    .Annotation( "SqlServer:Identity", "1, 1" ),
                Name = table.Column<string>( type: "nvarchar(300)", maxLength: 300, nullable: false ),
                Address = table.Column<string>( type: "nvarchar(500)", maxLength: 500, nullable: false ),
                OpenSince = table.Column<DateTime>( type: "datetime2", nullable: false )
            },
            constraints: table =>
            {
                table.PrimaryKey( "PK_Hotel", x => x.Id );
            } );
    }

    /// <inheritdoc />
    protected override void Down( MigrationBuilder migrationBuilder )
    {
        migrationBuilder.DropTable(
            name: "Hotel" );
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ExermonDevManager.Migrations
{
    public partial class AddBuildInDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    table: "models");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    table: "groupDatas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    table: "models",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    table: "groupDatas",
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}

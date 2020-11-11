using Microsoft.EntityFrameworkCore.Migrations;

namespace ExermonDevManager.Migrations
{
    public partial class UpdateRelateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "buildIn",
                table: "typeSettingModels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "typeSettingModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "typeSettingModels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "buildIn",
                table: "typeSettingModelFields",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "typeSettingModelFields",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "typeSettingModelFields",
                nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "buildIn",
            //    table: "modelInheritDerives",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "description",
            //    table: "modelInheritDerives",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "name",
            //    table: "modelInheritDerives",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "buildIn",
            //    table: "groupDataInheritDerives",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "description",
            //    table: "groupDataInheritDerives",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "name",
            //    table: "groupDataInheritDerives",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "buildIn",
                table: "typeSettingModels");

            migrationBuilder.DropColumn(
                name: "description",
                table: "typeSettingModels");

            migrationBuilder.DropColumn(
                name: "name",
                table: "typeSettingModels");

            migrationBuilder.DropColumn(
                name: "buildIn",
                table: "typeSettingModelFields");

            migrationBuilder.DropColumn(
                name: "description",
                table: "typeSettingModelFields");

            migrationBuilder.DropColumn(
                name: "name",
                table: "typeSettingModelFields");

            //migrationBuilder.DropColumn(
            //    name: "buildIn",
            //    table: "modelInheritDerives");

            //migrationBuilder.DropColumn(
            //    name: "description",
            //    table: "modelInheritDerives");

            //migrationBuilder.DropColumn(
            //    name: "name",
            //    table: "modelInheritDerives");

            //migrationBuilder.DropColumn(
            //    name: "buildIn",
            //    table: "groupDataInheritDerives");

            //migrationBuilder.DropColumn(
            //    name: "description",
            //    table: "groupDataInheritDerives");

            //migrationBuilder.DropColumn(
            //    name: "name",
            //    table: "groupDataInheritDerives");
			
        }
    }
}

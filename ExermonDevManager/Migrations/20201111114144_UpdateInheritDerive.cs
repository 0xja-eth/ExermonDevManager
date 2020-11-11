using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExermonDevManager.Migrations
{
    public partial class UpdateInheritDerive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

			migrationBuilder.CreateTable(
				name: "modelInheritDerives",
				columns: table => new {
					id = table.Column<int>(nullable: false)
						.Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
					deriveTypeId = table.Column<int>(nullable: false),
					inheritTypeId = table.Column<int>(nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_modelInheritDerives", x => x.id);
					table.ForeignKey(
						name: "FK_modelInheritDerives_models_deriveTypeId",
						column: x => x.deriveTypeId,
						principalTable: "models",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_modelInheritDerives_models_inheritTypeId",
						column: x => x.inheritTypeId,
						principalTable: "models",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "groupDataInheritDerives",
				columns: table => new {
					id = table.Column<int>(nullable: false)
						.Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
					deriveTypeId = table.Column<int>(nullable: false),
					inheritTypeId = table.Column<int>(nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_groupDataInheritDerives", x => x.id);
					table.ForeignKey(
						name: "FK_groupDataInheritDerives_gd_deriveTypeId",
						column: x => x.deriveTypeId,
						principalTable: "groupDatas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_groupDataInheritDerives_gd_inheritTypeId",
						column: x => x.inheritTypeId,
						principalTable: "groupDatas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.AddColumn<bool>(
				name: "buildIn",
				table: "modelInheritDerives",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<string>(
				name: "description",
				table: "modelInheritDerives",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "name",
				table: "modelInheritDerives",
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "buildIn",
				table: "groupDataInheritDerives",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<string>(
				name: "description",
				table: "groupDataInheritDerives",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "name",
				table: "groupDataInheritDerives",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_groupDataInheritDerives_groupDatas_inheritTypeId",
                table: "groupDataInheritDerives");

            migrationBuilder.DropForeignKey(
                name: "FK_modelInheritDerives_models_inheritTypeId",
                table: "modelInheritDerives");

            migrationBuilder.DropIndex(
                name: "IX_modelInheritDerives_inheritTypeId",
                table: "modelInheritDerives");

            migrationBuilder.DropIndex(
                name: "IX_groupDataInheritDerives_inheritTypeId",
                table: "groupDataInheritDerives");

            migrationBuilder.DropColumn(
                name: "inheritTypeId",
                table: "modelInheritDerives");

            migrationBuilder.DropColumn(
                name: "inheritTypeId",
                table: "groupDataInheritDerives");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "models",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "inheritTypeId",
                table: "modelInheritDerives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "groupDatas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "inheritTypeId",
                table: "groupDataInheritDerives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_modelInheritDerives_inheritTypeId",
                table: "modelInheritDerives",
                column: "inheritTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_groupDataInheritDerives_inheritTypeId",
                table: "groupDataInheritDerives",
                column: "inheritTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_groupDataInheritDerives_groupDatas_inheritTypeId",
                table: "groupDataInheritDerives",
                column: "inheritTypeId",
                principalTable: "groupDatas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modelInheritDerives_models_inheritTypeId",
                table: "modelInheritDerives",
                column: "inheritTypeId",
                principalTable: "models",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

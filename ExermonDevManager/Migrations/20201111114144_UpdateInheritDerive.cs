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

			migrationBuilder.CreateIndex(
				name: "IX_modelInheritDerives_deriveTypeId",
				table: "modelInheritDerives",
				column: "deriveTypeId");

			migrationBuilder.CreateIndex(
				name: "IX_modelInheritDerives_inheritTypeId",
				table: "modelInheritDerives",
				column: "inheritTypeId");

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

			migrationBuilder.CreateIndex(
				name: "IX_groupDataInheritDerives_deriveTypeId",
				table: "groupDataInheritDerives",
				column: "deriveTypeId");

			migrationBuilder.CreateIndex(
				name: "IX_groupDataInheritDerives_inheritTypeId",
				table: "groupDataInheritDerives",
				column: "inheritTypeId");

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

		protected override void Down(MigrationBuilder migrationBuilder) {

			migrationBuilder.DropTable(
				name: "modelInheritDerives");

			migrationBuilder.DropTable(
				name: "groupDataInheritDerives");
		}
    }
}

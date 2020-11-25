using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExermonDevManager.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoreFramework_customenumgroups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreFramework_customenumgroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_groupdatas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    derivable = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_groupdatas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_modules",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_modules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CoreFramework_customenums",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    value = table.Column<int>(nullable: false),
                    enumGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreFramework_customenums", x => x.id);
                    table.ForeignKey(
                        name: "FK_CoreFramework_customenums_CoreFramework_customenumgroups_enu~",
                        column: x => x.enumGroupId,
                        principalTable: "CoreFramework_customenumgroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_groupdatainheritderives",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    deriveTypeId = table.Column<int>(nullable: false),
                    inheritTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_groupdatainheritderives", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_groupdatainheritderives_ExerUnity_groupdatas_deriv~",
                        column: x => x.deriveTypeId,
                        principalTable: "ExerUnity_groupdatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerUnity_groupdatainheritderives_ExerUnity_groupdatas_inher~",
                        column: x => x.inheritTypeId,
                        principalTable: "ExerUnity_groupdatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_emitinterfaces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    Moduleid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_emitinterfaces", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_emitinterfaces_ExerUnity_modules_Moduleid",
                        column: x => x.Moduleid,
                        principalTable: "ExerUnity_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_exception_s",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    value = table.Column<int>(nullable: false),
                    alertText = table.Column<string>(nullable: true),
                    moduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_exception_s", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_exception_s_ExerUnity_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "ExerUnity_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_models",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    derivable = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    moduleId = table.Column<int>(nullable: false),
                    abstract_ = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_models", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_models_ExerUnity_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "ExerUnity_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_services",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    moduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_services", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_services_ExerUnity_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "ExerUnity_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_modelfields",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    ownerTypeId = table.Column<int>(nullable: true),
                    typeId = table.Column<int>(nullable: false),
                    dimension = table.Column<int>(nullable: false),
                    useList = table.Column<bool>(nullable: false),
                    protectedSet = table.Column<bool>(nullable: false),
                    fDefault = table.Column<string>(nullable: true),
                    defaultNew = table.Column<bool>(nullable: false),
                    keyName = table.Column<string>(nullable: true),
                    format = table.Column<string>(nullable: true),
                    autoLoad = table.Column<bool>(nullable: false),
                    autoConvert = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_modelfields", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_modelfields_ExerUnity_models_ownerTypeId",
                        column: x => x.ownerTypeId,
                        principalTable: "ExerUnity_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerUnity_modelfields_ExerUnity_models_typeId",
                        column: x => x.typeId,
                        principalTable: "ExerUnity_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_modelinheritderives",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    deriveTypeId = table.Column<int>(nullable: false),
                    inheritTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_modelinheritderives", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_modelinheritderives_ExerUnity_models_deriveTypeId",
                        column: x => x.deriveTypeId,
                        principalTable: "ExerUnity_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerUnity_modelinheritderives_ExerUnity_models_inheritTypeId",
                        column: x => x.inheritTypeId,
                        principalTable: "ExerUnity_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_reqresinterfaces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    serviceId = table.Column<int>(nullable: false),
                    route = table.Column<string>(nullable: true),
                    operName = table.Column<string>(nullable: true),
                    Moduleid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_reqresinterfaces", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_reqresinterfaces_ExerUnity_modules_Moduleid",
                        column: x => x.Moduleid,
                        principalTable: "ExerUnity_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerUnity_reqresinterfaces_ExerUnity_services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "ExerUnity_services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerUnity_interfaceparams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    ownerTypeId = table.Column<int>(nullable: true),
                    typeId = table.Column<int>(nullable: false),
                    dimension = table.Column<int>(nullable: false),
                    reqInterfaceId = table.Column<int>(nullable: true),
                    resInterfaceId = table.Column<int>(nullable: true),
                    emitInterfaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerUnity_interfaceparams", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerUnity_interfaceparams_ExerUnity_emitinterfaces_emitInter~",
                        column: x => x.emitInterfaceId,
                        principalTable: "ExerUnity_emitinterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerUnity_interfaceparams_ExerUnity_groupdatas_ownerTypeId",
                        column: x => x.ownerTypeId,
                        principalTable: "ExerUnity_groupdatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerUnity_interfaceparams_ExerUnity_reqresinterfaces_reqInte~",
                        column: x => x.reqInterfaceId,
                        principalTable: "ExerUnity_reqresinterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerUnity_interfaceparams_ExerUnity_reqresinterfaces_resInte~",
                        column: x => x.resInterfaceId,
                        principalTable: "ExerUnity_reqresinterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerUnity_interfaceparams_ExerUnity_groupdatas_typeId",
                        column: x => x.typeId,
                        principalTable: "ExerUnity_groupdatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoreFramework_customenums_enumGroupId",
                table: "CoreFramework_customenums",
                column: "enumGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_emitinterfaces_Moduleid",
                table: "ExerUnity_emitinterfaces",
                column: "Moduleid");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_exception_s_moduleId",
                table: "ExerUnity_exception_s",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_groupdatainheritderives_deriveTypeId",
                table: "ExerUnity_groupdatainheritderives",
                column: "deriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_groupdatainheritderives_inheritTypeId",
                table: "ExerUnity_groupdatainheritderives",
                column: "inheritTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_interfaceparams_emitInterfaceId",
                table: "ExerUnity_interfaceparams",
                column: "emitInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_interfaceparams_ownerTypeId",
                table: "ExerUnity_interfaceparams",
                column: "ownerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_interfaceparams_reqInterfaceId",
                table: "ExerUnity_interfaceparams",
                column: "reqInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_interfaceparams_resInterfaceId",
                table: "ExerUnity_interfaceparams",
                column: "resInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_interfaceparams_typeId",
                table: "ExerUnity_interfaceparams",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_modelfields_ownerTypeId",
                table: "ExerUnity_modelfields",
                column: "ownerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_modelfields_typeId",
                table: "ExerUnity_modelfields",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_modelinheritderives_deriveTypeId",
                table: "ExerUnity_modelinheritderives",
                column: "deriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_modelinheritderives_inheritTypeId",
                table: "ExerUnity_modelinheritderives",
                column: "inheritTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_models_moduleId",
                table: "ExerUnity_models",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_reqresinterfaces_Moduleid",
                table: "ExerUnity_reqresinterfaces",
                column: "Moduleid");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_reqresinterfaces_serviceId",
                table: "ExerUnity_reqresinterfaces",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerUnity_services_moduleId",
                table: "ExerUnity_services",
                column: "moduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoreFramework_customenums");

            migrationBuilder.DropTable(
                name: "ExerUnity_exception_s");

            migrationBuilder.DropTable(
                name: "ExerUnity_groupdatainheritderives");

            migrationBuilder.DropTable(
                name: "ExerUnity_interfaceparams");

            migrationBuilder.DropTable(
                name: "ExerUnity_modelfields");

            migrationBuilder.DropTable(
                name: "ExerUnity_modelinheritderives");

            migrationBuilder.DropTable(
                name: "CoreFramework_customenumgroups");

            migrationBuilder.DropTable(
                name: "ExerUnity_emitinterfaces");

            migrationBuilder.DropTable(
                name: "ExerUnity_groupdatas");

            migrationBuilder.DropTable(
                name: "ExerUnity_reqresinterfaces");

            migrationBuilder.DropTable(
                name: "ExerUnity_models");

            migrationBuilder.DropTable(
                name: "ExerUnity_services");

            migrationBuilder.DropTable(
                name: "ExerUnity_modules");
        }
    }
}

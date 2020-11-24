using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExermonDevManager.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "channelstags",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channelstags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customenumgroups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    isFrontend = table.Column<bool>(nullable: false),
                    isBackend = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customenumgroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "djangofieldtypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_djangofieldtypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "djangoondeletechoices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_djangoondeletechoices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "functions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_functions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groupdatas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    derivable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupdatas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customenums",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    code = table.Column<int>(nullable: false),
                    enumGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customenums", x => x.id);
                    table.ForeignKey(
                        name: "FK_customenums_customenumgroups_enumGroupId",
                        column: x => x.enumGroupId,
                        principalTable: "customenumgroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InheritDerive",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    deriveTypeId = table.Column<int>(nullable: false),
                    inheritTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InheritDerive", x => x.id);
                    table.ForeignKey(
                        name: "FK_InheritDerive_groupdatas_deriveTypeId",
                        column: x => x.deriveTypeId,
                        principalTable: "groupdatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InheritDerive_groupdatas_inheritTypeId",
                        column: x => x.inheritTypeId,
                        principalTable: "groupdatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emitinterfaces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    bModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emitinterfaces", x => x.id);
                    table.ForeignKey(
                        name: "FK_emitinterfaces_Module_bModuleId",
                        column: x => x.bModuleId,
                        principalTable: "Module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exception_s",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    code = table.Column<int>(nullable: false),
                    alertText = table.Column<string>(nullable: true),
                    moduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exception_s", x => x.id);
                    table.ForeignKey(
                        name: "FK_exception_s_Module_moduleId",
                        column: x => x.moduleId,
                        principalTable: "Module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    derivable = table.Column<bool>(nullable: false),
                    moduleId = table.Column<int>(nullable: false),
                    isBackend = table.Column<bool>(nullable: false),
                    isFrontend = table.Column<bool>(nullable: false),
                    abstract_ = table.Column<bool>(nullable: false),
                    keyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.id);
                    table.ForeignKey(
                        name: "FK_models_Module_moduleId",
                        column: x => x.moduleId,
                        principalTable: "Module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reqresinterfaces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    route = table.Column<string>(nullable: true),
                    bModuleId = table.Column<int>(nullable: false),
                    bFunc = table.Column<string>(nullable: true),
                    bTagId = table.Column<int>(nullable: false),
                    fName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reqresinterfaces", x => x.id);
                    table.ForeignKey(
                        name: "FK_reqresinterfaces_Module_bModuleId",
                        column: x => x.bModuleId,
                        principalTable: "Module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reqresinterfaces_channelstags_bTagId",
                        column: x => x.bTagId,
                        principalTable: "channelstags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InheritDerive1",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    deriveTypeId = table.Column<int>(nullable: false),
                    inheritTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InheritDerive1", x => x.id);
                    table.ForeignKey(
                        name: "FK_InheritDerive1_models_deriveTypeId",
                        column: x => x.deriveTypeId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InheritDerive1_models_inheritTypeId",
                        column: x => x.inheritTypeId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modelfields",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    ownerTypeId = table.Column<int>(nullable: true),
                    isBackend_ = table.Column<bool>(nullable: false),
                    isFrontend_ = table.Column<bool>(nullable: false),
                    keyName = table.Column<string>(nullable: true),
                    fTypeId = table.Column<int>(nullable: false),
                    dimension = table.Column<int>(nullable: false),
                    useList = table.Column<bool>(nullable: false),
                    protectedSet = table.Column<bool>(nullable: false),
                    format = table.Column<string>(nullable: true),
                    autoLoad = table.Column<bool>(nullable: false),
                    autoConvert = table.Column<bool>(nullable: false),
                    fDefault = table.Column<string>(nullable: true),
                    defaultNew = table.Column<bool>(nullable: false),
                    bTypeId = table.Column<int>(nullable: false),
                    bDefault = table.Column<string>(nullable: true),
                    maxLength = table.Column<int>(nullable: false),
                    null_ = table.Column<bool>(nullable: false),
                    blank = table.Column<bool>(nullable: false),
                    unique = table.Column<bool>(nullable: false),
                    verboseName = table.Column<string>(nullable: true),
                    choicesId = table.Column<int>(nullable: true),
                    autoNow = table.Column<bool>(nullable: false),
                    autoNowAdd = table.Column<bool>(nullable: false),
                    uploadTo = table.Column<string>(nullable: true),
                    toModelId = table.Column<int>(nullable: true),
                    onDeleteId = table.Column<int>(nullable: true),
                    listDisplay = table.Column<bool>(nullable: false),
                    listEditable = table.Column<bool>(nullable: false),
                    typeFilter = table.Column<string>(nullable: true),
                    typeExclude = table.Column<string>(nullable: true),
                    convertFunc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelfields", x => x.id);
                    table.ForeignKey(
                        name: "FK_modelfields_djangofieldtypes_bTypeId",
                        column: x => x.bTypeId,
                        principalTable: "djangofieldtypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modelfields_customenumgroups_choicesId",
                        column: x => x.choicesId,
                        principalTable: "customenumgroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_modelfields_models_fTypeId",
                        column: x => x.fTypeId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modelfields_djangoondeletechoices_onDeleteId",
                        column: x => x.onDeleteId,
                        principalTable: "djangoondeletechoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_modelfields_models_ownerTypeId",
                        column: x => x.ownerTypeId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_modelfields_models_toModelId",
                        column: x => x.toModelId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "typesettings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    modelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typesettings", x => x.id);
                    table.ForeignKey(
                        name: "FK_typesettings_models_modelId",
                        column: x => x.modelId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interfaceparams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    ownerTypeId = table.Column<int>(nullable: true),
                    typeId = table.Column<int>(nullable: false),
                    dimension = table.Column<int>(nullable: false),
                    reqInterfaceId = table.Column<int>(nullable: true),
                    resInterfaceId = table.Column<int>(nullable: true),
                    emitInterfaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interfaceparams", x => x.id);
                    table.ForeignKey(
                        name: "FK_interfaceparams_emitinterfaces_emitInterfaceId",
                        column: x => x.emitInterfaceId,
                        principalTable: "emitinterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_interfaceparams_groupdatas_ownerTypeId",
                        column: x => x.ownerTypeId,
                        principalTable: "groupdatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_interfaceparams_reqresinterfaces_reqInterfaceId",
                        column: x => x.reqInterfaceId,
                        principalTable: "reqresinterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_interfaceparams_reqresinterfaces_resInterfaceId",
                        column: x => x.resInterfaceId,
                        principalTable: "reqresinterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_interfaceparams_groupdatas_typeId",
                        column: x => x.typeId,
                        principalTable: "groupdatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "typesettingmodelfields",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    typeSettingId = table.Column<int>(nullable: false),
                    modelFieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typesettingmodelfields", x => x.id);
                    table.ForeignKey(
                        name: "FK_typesettingmodelfields_modelfields_modelFieldId",
                        column: x => x.modelFieldId,
                        principalTable: "modelfields",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_typesettingmodelfields_typesettings_typeSettingId",
                        column: x => x.typeSettingId,
                        principalTable: "typesettings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "typesettingmodels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false),
                    typeSettingId = table.Column<int>(nullable: false),
                    modelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typesettingmodels", x => x.id);
                    table.ForeignKey(
                        name: "FK_typesettingmodels_models_modelId",
                        column: x => x.modelId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_typesettingmodels_typesettings_typeSettingId",
                        column: x => x.typeSettingId,
                        principalTable: "typesettings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customenums_enumGroupId",
                table: "customenums",
                column: "enumGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_emitinterfaces_bModuleId",
                table: "emitinterfaces",
                column: "bModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_exception_s_moduleId",
                table: "exception_s",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_InheritDerive_deriveTypeId",
                table: "InheritDerive",
                column: "deriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InheritDerive_inheritTypeId",
                table: "InheritDerive",
                column: "inheritTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InheritDerive1_deriveTypeId",
                table: "InheritDerive1",
                column: "deriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InheritDerive1_inheritTypeId",
                table: "InheritDerive1",
                column: "inheritTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceparams_emitInterfaceId",
                table: "interfaceparams",
                column: "emitInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceparams_ownerTypeId",
                table: "interfaceparams",
                column: "ownerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceparams_reqInterfaceId",
                table: "interfaceparams",
                column: "reqInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceparams_resInterfaceId",
                table: "interfaceparams",
                column: "resInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceparams_typeId",
                table: "interfaceparams",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelfields_bTypeId",
                table: "modelfields",
                column: "bTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelfields_choicesId",
                table: "modelfields",
                column: "choicesId");

            migrationBuilder.CreateIndex(
                name: "IX_modelfields_fTypeId",
                table: "modelfields",
                column: "fTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelfields_onDeleteId",
                table: "modelfields",
                column: "onDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_modelfields_ownerTypeId",
                table: "modelfields",
                column: "ownerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelfields_toModelId",
                table: "modelfields",
                column: "toModelId");

            migrationBuilder.CreateIndex(
                name: "IX_models_moduleId",
                table: "models",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_reqresinterfaces_bModuleId",
                table: "reqresinterfaces",
                column: "bModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_reqresinterfaces_bTagId",
                table: "reqresinterfaces",
                column: "bTagId");

            migrationBuilder.CreateIndex(
                name: "IX_typesettingmodelfields_modelFieldId",
                table: "typesettingmodelfields",
                column: "modelFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_typesettingmodelfields_typeSettingId",
                table: "typesettingmodelfields",
                column: "typeSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_typesettingmodels_modelId",
                table: "typesettingmodels",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_typesettingmodels_typeSettingId",
                table: "typesettingmodels",
                column: "typeSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_typesettings_modelId",
                table: "typesettings",
                column: "modelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customenums");

            migrationBuilder.DropTable(
                name: "exception_s");

            migrationBuilder.DropTable(
                name: "functions");

            migrationBuilder.DropTable(
                name: "InheritDerive");

            migrationBuilder.DropTable(
                name: "InheritDerive1");

            migrationBuilder.DropTable(
                name: "interfaceparams");

            migrationBuilder.DropTable(
                name: "typesettingmodelfields");

            migrationBuilder.DropTable(
                name: "typesettingmodels");

            migrationBuilder.DropTable(
                name: "emitinterfaces");

            migrationBuilder.DropTable(
                name: "groupdatas");

            migrationBuilder.DropTable(
                name: "reqresinterfaces");

            migrationBuilder.DropTable(
                name: "modelfields");

            migrationBuilder.DropTable(
                name: "typesettings");

            migrationBuilder.DropTable(
                name: "channelstags");

            migrationBuilder.DropTable(
                name: "djangofieldtypes");

            migrationBuilder.DropTable(
                name: "customenumgroups");

            migrationBuilder.DropTable(
                name: "djangoondeletechoices");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "Module");
        }
    }
}

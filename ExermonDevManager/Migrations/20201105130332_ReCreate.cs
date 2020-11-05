using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ExermonDevManager.Migrations
{
    public partial class ReCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "channelTags",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channelTags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customEnumGroups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    isFrontend = table.Column<bool>(nullable: false),
                    isBackend = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customEnumGroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "djangoFieldTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_djangoFieldTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "djangoOnDeleteChoices",
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
                    table.PrimaryKey("PK_djangoOnDeleteChoices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groupDatas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    code = table.Column<string>(nullable: true),
                    derivable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupDatas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customEnums",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    code = table.Column<int>(nullable: false),
                    enumGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customEnums", x => x.id);
                    table.ForeignKey(
                        name: "FK_customEnums_customEnumGroups_enumGroupId",
                        column: x => x.enumGroupId,
                        principalTable: "customEnumGroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupDataInheritDerives",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    deriveTypeId = table.Column<int>(nullable: false),
                    inhertTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupDataInheritDerives", x => x.id);
                    table.ForeignKey(
                        name: "FK_groupDataInheritDerives_groupDatas_deriveTypeId",
                        column: x => x.deriveTypeId,
                        principalTable: "groupDatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groupDataInheritDerives_groupDatas_inhertTypeId",
                        column: x => x.inhertTypeId,
                        principalTable: "groupDatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emitInterfaces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    type = table.Column<string>(nullable: true),
                    bModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emitInterfaces", x => x.id);
                    table.ForeignKey(
                        name: "FK_emitInterfaces_modules_bModuleId",
                        column: x => x.bModuleId,
                        principalTable: "modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exceptions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    code = table.Column<int>(nullable: false),
                    alertText = table.Column<string>(nullable: true),
                    moduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exceptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_exceptions_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "modules",
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
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
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
                        name: "FK_models_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reqResInterfaces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    route = table.Column<string>(nullable: true),
                    bModuleId = table.Column<int>(nullable: false),
                    bFunc = table.Column<string>(nullable: true),
                    bTagId = table.Column<int>(nullable: false),
                    fName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reqResInterfaces", x => x.id);
                    table.ForeignKey(
                        name: "FK_reqResInterfaces_modules_bModuleId",
                        column: x => x.bModuleId,
                        principalTable: "modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reqResInterfaces_channelTags_bTagId",
                        column: x => x.bTagId,
                        principalTable: "channelTags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modelFields",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
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
                    choicesId = table.Column<int>(nullable: false),
                    autoNow = table.Column<bool>(nullable: false),
                    autoNowAdd = table.Column<bool>(nullable: false),
                    uploadTo = table.Column<string>(nullable: true),
                    toModelId = table.Column<int>(nullable: false),
                    onDeleteId = table.Column<int>(nullable: false),
                    listDisplay = table.Column<bool>(nullable: false),
                    listEditable = table.Column<bool>(nullable: false),
                    typeFilter = table.Column<string>(nullable: true),
                    typeExclude = table.Column<string>(nullable: true),
                    convertFunc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelFields", x => x.id);
                    table.ForeignKey(
                        name: "FK_modelFields_djangoFieldTypes_bTypeId",
                        column: x => x.bTypeId,
                        principalTable: "djangoFieldTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modelFields_customEnumGroups_choicesId",
                        column: x => x.choicesId,
                        principalTable: "customEnumGroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modelFields_models_fTypeId",
                        column: x => x.fTypeId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modelFields_djangoOnDeleteChoices_onDeleteId",
                        column: x => x.onDeleteId,
                        principalTable: "djangoOnDeleteChoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modelFields_models_ownerTypeId",
                        column: x => x.ownerTypeId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_modelFields_models_toModelId",
                        column: x => x.toModelId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modelInheritDerives",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    deriveTypeId = table.Column<int>(nullable: false),
                    inhertTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelInheritDerives", x => x.id);
                    table.ForeignKey(
                        name: "FK_modelInheritDerives_models_deriveTypeId",
                        column: x => x.deriveTypeId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modelInheritDerives_models_inhertTypeId",
                        column: x => x.inhertTypeId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "typeSettings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    modelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeSettings", x => x.id);
                    table.ForeignKey(
                        name: "FK_typeSettings_models_modelId",
                        column: x => x.modelId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interfaceParams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    buildIn = table.Column<bool>(nullable: false, defaultValue: false),
                    ownerTypeId = table.Column<int>(nullable: true),
                    typeId = table.Column<int>(nullable: false),
                    dimension = table.Column<int>(nullable: false),
                    reqInterfaceId = table.Column<int>(nullable: true),
                    resInterfaceId = table.Column<int>(nullable: true),
                    emitInterfaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interfaceParams", x => x.id);
                    table.ForeignKey(
                        name: "FK_interfaceParams_emitInterfaces_emitInterfaceId",
                        column: x => x.emitInterfaceId,
                        principalTable: "emitInterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_interfaceParams_groupDatas_ownerTypeId",
                        column: x => x.ownerTypeId,
                        principalTable: "groupDatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_interfaceParams_reqResInterfaces_reqInterfaceId",
                        column: x => x.reqInterfaceId,
                        principalTable: "reqResInterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_interfaceParams_reqResInterfaces_resInterfaceId",
                        column: x => x.resInterfaceId,
                        principalTable: "reqResInterfaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_interfaceParams_groupDatas_typeId",
                        column: x => x.typeId,
                        principalTable: "groupDatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "typeSettingModelFields",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    typeSettingId = table.Column<int>(nullable: false),
                    modelFieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeSettingModelFields", x => x.id);
                    table.ForeignKey(
                        name: "FK_typeSettingModelFields_modelFields_modelFieldId",
                        column: x => x.modelFieldId,
                        principalTable: "modelFields",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_typeSettingModelFields_typeSettings_typeSettingId",
                        column: x => x.typeSettingId,
                        principalTable: "typeSettings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "typeSettingModels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    typeSettingId = table.Column<int>(nullable: false),
                    modelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeSettingModels", x => x.id);
                    table.ForeignKey(
                        name: "FK_typeSettingModels_models_modelId",
                        column: x => x.modelId,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_typeSettingModels_typeSettings_typeSettingId",
                        column: x => x.typeSettingId,
                        principalTable: "typeSettings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customEnums_enumGroupId",
                table: "customEnums",
                column: "enumGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_emitInterfaces_bModuleId",
                table: "emitInterfaces",
                column: "bModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_exceptions_moduleId",
                table: "exceptions",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_groupDataInheritDerives_deriveTypeId",
                table: "groupDataInheritDerives",
                column: "deriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_groupDataInheritDerives_inhertTypeId",
                table: "groupDataInheritDerives",
                column: "inhertTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceParams_emitInterfaceId",
                table: "interfaceParams",
                column: "emitInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceParams_ownerTypeId",
                table: "interfaceParams",
                column: "ownerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceParams_reqInterfaceId",
                table: "interfaceParams",
                column: "reqInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceParams_resInterfaceId",
                table: "interfaceParams",
                column: "resInterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_interfaceParams_typeId",
                table: "interfaceParams",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelFields_bTypeId",
                table: "modelFields",
                column: "bTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelFields_choicesId",
                table: "modelFields",
                column: "choicesId");

            migrationBuilder.CreateIndex(
                name: "IX_modelFields_fTypeId",
                table: "modelFields",
                column: "fTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelFields_onDeleteId",
                table: "modelFields",
                column: "onDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_modelFields_ownerTypeId",
                table: "modelFields",
                column: "ownerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelFields_toModelId",
                table: "modelFields",
                column: "toModelId");

            migrationBuilder.CreateIndex(
                name: "IX_modelInheritDerives_deriveTypeId",
                table: "modelInheritDerives",
                column: "deriveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_modelInheritDerives_inhertTypeId",
                table: "modelInheritDerives",
                column: "inhertTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_models_moduleId",
                table: "models",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_reqResInterfaces_bModuleId",
                table: "reqResInterfaces",
                column: "bModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_reqResInterfaces_bTagId",
                table: "reqResInterfaces",
                column: "bTagId");

            migrationBuilder.CreateIndex(
                name: "IX_typeSettingModelFields_modelFieldId",
                table: "typeSettingModelFields",
                column: "modelFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_typeSettingModelFields_typeSettingId",
                table: "typeSettingModelFields",
                column: "typeSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_typeSettingModels_modelId",
                table: "typeSettingModels",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_typeSettingModels_typeSettingId",
                table: "typeSettingModels",
                column: "typeSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_typeSettings_modelId",
                table: "typeSettings",
                column: "modelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customEnums");

            migrationBuilder.DropTable(
                name: "exceptions");

            migrationBuilder.DropTable(
                name: "groupDataInheritDerives");

            migrationBuilder.DropTable(
                name: "interfaceParams");

            migrationBuilder.DropTable(
                name: "modelInheritDerives");

            migrationBuilder.DropTable(
                name: "Type_");

            migrationBuilder.DropTable(
                name: "typeSettingModelFields");

            migrationBuilder.DropTable(
                name: "typeSettingModels");

            migrationBuilder.DropTable(
                name: "emitInterfaces");

            migrationBuilder.DropTable(
                name: "groupDatas");

            migrationBuilder.DropTable(
                name: "reqResInterfaces");

            migrationBuilder.DropTable(
                name: "modelFields");

            migrationBuilder.DropTable(
                name: "typeSettings");

            migrationBuilder.DropTable(
                name: "channelTags");

            migrationBuilder.DropTable(
                name: "djangoFieldTypes");

            migrationBuilder.DropTable(
                name: "customEnumGroups");

            migrationBuilder.DropTable(
                name: "djangoOnDeleteChoices");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "modules");
        }
    }
}

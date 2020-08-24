﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Api.Migrations
{
    public partial class _202008181512 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoRepairStation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoRepairStation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BAH_MOProcessFlow",
                columns: table => new
                {
                    bah_c031 = table.Column<string>(nullable: false),
                    bah_c12 = table.Column<string>(nullable: false),
                    bah_c02 = table.Column<int>(nullable: false),
                    bah_c03 = table.Column<int>(nullable: false),
                    bah_c04 = table.Column<string>(nullable: true),
                    bah_c05 = table.Column<int>(nullable: false),
                    bah_c06 = table.Column<int>(nullable: false),
                    bah_c07 = table.Column<string>(nullable: true),
                    bah_c08 = table.Column<string>(nullable: true),
                    bah_c09 = table.Column<string>(nullable: true),
                    bah_c10 = table.Column<string>(nullable: true),
                    bah_n11 = table.Column<int>(nullable: false),
                    bah_c13 = table.Column<string>(nullable: true),
                    bah_cCreateUser = table.Column<string>(nullable: true),
                    bah_dCreateDate = table.Column<DateTime>(nullable: true),
                    bah_dLastUpdateDate = table.Column<DateTime>(nullable: true),
                    bah_cLastUpdateUser = table.Column<string>(nullable: true),
                    bah_cCustID = table.Column<string>(nullable: true),
                    bah_cConfirmUser = table.Column<string>(nullable: true),
                    bah_dConfirmDate = table.Column<DateTime>(nullable: true),
                    bah_cState = table.Column<string>(nullable: true),
                    bah_cValid = table.Column<string>(nullable: true),
                    bah_n12 = table.Column<int>(nullable: false),
                    bah_c14 = table.Column<string>(nullable: true),
                    bah_nEdition = table.Column<string>(nullable: true),
                    bah_nConfig = table.Column<string>(nullable: true),
                    bah_cTimeoutControl = table.Column<decimal>(nullable: false),
                    bah_cdescribe = table.Column<string>(nullable: true),
                    bah_cMinTime = table.Column<decimal>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAH_MOProcessFlow", x => new { x.bah_c031, x.bah_c12 });
                });

            migrationBuilder.CreateTable(
                name: "BAJ_MO",
                columns: table => new
                {
                    baj_c02 = table.Column<string>(nullable: false),
                    baj_n01 = table.Column<int>(nullable: false),
                    baj_c03 = table.Column<string>(nullable: true),
                    baj_c04 = table.Column<string>(nullable: true),
                    baj_c05 = table.Column<string>(nullable: true),
                    baj_c06 = table.Column<string>(nullable: true),
                    baj_c07 = table.Column<string>(nullable: true),
                    baj_c08 = table.Column<string>(nullable: true),
                    baj_c09 = table.Column<string>(nullable: true),
                    baj_c10 = table.Column<string>(nullable: true),
                    baj_c11 = table.Column<string>(nullable: true),
                    baj_c12 = table.Column<string>(nullable: true),
                    baj_c13 = table.Column<string>(nullable: true),
                    baj_c14 = table.Column<string>(nullable: true),
                    baj_c15 = table.Column<string>(nullable: true),
                    baj_c16 = table.Column<string>(nullable: true),
                    baj_c17 = table.Column<string>(nullable: true),
                    baj_c18 = table.Column<string>(nullable: true),
                    baj_c19 = table.Column<string>(nullable: true),
                    baj_c20 = table.Column<string>(nullable: true),
                    baj_c21 = table.Column<string>(nullable: true),
                    baj_c22 = table.Column<string>(nullable: true),
                    baj_c23 = table.Column<string>(nullable: true),
                    baj_c24 = table.Column<string>(nullable: true),
                    baj_n25 = table.Column<int>(nullable: true),
                    baj_c26 = table.Column<string>(nullable: true),
                    baj_c27 = table.Column<string>(nullable: true),
                    baj_c28 = table.Column<string>(nullable: true),
                    baj_c29 = table.Column<string>(nullable: true),
                    baj_c30 = table.Column<string>(nullable: true),
                    baj_c31 = table.Column<string>(nullable: true),
                    baj_c32 = table.Column<string>(nullable: true),
                    baj_c33 = table.Column<string>(nullable: true),
                    baj_c34 = table.Column<string>(nullable: true),
                    baj_c35 = table.Column<string>(nullable: true),
                    baj_c36 = table.Column<string>(nullable: true),
                    baj_c37 = table.Column<string>(nullable: true),
                    baj_c38 = table.Column<string>(nullable: true),
                    baj_c39 = table.Column<string>(nullable: true),
                    baj_c40 = table.Column<string>(nullable: true),
                    baj_c41 = table.Column<string>(nullable: true),
                    baj_c42 = table.Column<string>(nullable: true),
                    baj_c43 = table.Column<string>(nullable: true),
                    baj_c44 = table.Column<string>(nullable: true),
                    baj_c45 = table.Column<string>(nullable: true),
                    baj_c46 = table.Column<string>(nullable: true),
                    baj_c47 = table.Column<string>(nullable: true),
                    baj_c48 = table.Column<string>(nullable: true),
                    baj_c49 = table.Column<string>(nullable: true),
                    baj_c50 = table.Column<string>(nullable: true),
                    baj_c51 = table.Column<string>(nullable: true),
                    baj_c52 = table.Column<string>(nullable: true),
                    baj_c53 = table.Column<string>(nullable: true),
                    baj_c54 = table.Column<string>(nullable: true),
                    baj_n55 = table.Column<int>(nullable: true),
                    baj_n56 = table.Column<int>(nullable: true),
                    baj_c57 = table.Column<string>(nullable: true),
                    baj_c58 = table.Column<string>(nullable: true),
                    baj_c59 = table.Column<string>(nullable: true),
                    baj_c60 = table.Column<string>(nullable: true),
                    baj_c61 = table.Column<string>(nullable: true),
                    baj_c62 = table.Column<string>(nullable: true),
                    baj_c63 = table.Column<string>(nullable: true),
                    baj_c64 = table.Column<string>(nullable: true),
                    baj_c65 = table.Column<string>(nullable: true),
                    baj_c66 = table.Column<string>(nullable: true),
                    baj_n67 = table.Column<int>(nullable: true),
                    baj_c68 = table.Column<string>(nullable: true),
                    baj_n69 = table.Column<int>(nullable: true),
                    baj_n70 = table.Column<int>(nullable: true),
                    baj_c71 = table.Column<string>(nullable: true),
                    baj_c72 = table.Column<string>(nullable: true),
                    baj_c73 = table.Column<string>(nullable: true),
                    baj_n74 = table.Column<int>(nullable: true),
                    baj_n75 = table.Column<int>(nullable: true),
                    baj_n76 = table.Column<int>(nullable: true),
                    baj_n77 = table.Column<int>(nullable: true),
                    baj_c78 = table.Column<string>(nullable: true),
                    baj_c79 = table.Column<string>(nullable: true),
                    baj_c80 = table.Column<string>(nullable: true),
                    baj_c81 = table.Column<string>(nullable: true),
                    baj_c82 = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUserId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    BuId = table.Column<string>(nullable: true),
                    DeptId = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    UpdateUserName = table.Column<string>(nullable: true),
                    baj_cAUFNR = table.Column<string>(nullable: true),
                    baj_cPLNUM = table.Column<string>(nullable: true),
                    baj_cWERKS = table.Column<string>(nullable: true),
                    baj_cAUART = table.Column<string>(nullable: true),
                    baj_cMAKTX = table.Column<string>(nullable: true),
                    baj_cZPROJ = table.Column<string>(nullable: true),
                    baj_cMATKL = table.Column<string>(nullable: true),
                    baj_cFTRMI = table.Column<string>(nullable: true),
                    baj_cZZBOMV = table.Column<string>(nullable: true),
                    baj_cKDMAT = table.Column<string>(nullable: true),
                    baj_cZP_KH = table.Column<string>(nullable: true),
                    baj_cZZLINE = table.Column<string>(nullable: true),
                    baj_nVersionName = table.Column<string>(nullable: true),
                    baj_cColorA = table.Column<string>(nullable: true),
                    baj_cColorB = table.Column<string>(nullable: true),
                    baj_cColorC = table.Column<string>(nullable: true),
                    baj_cUPC = table.Column<string>(nullable: true),
                    baj_nFactoryCode = table.Column<string>(nullable: true),
                    baj_cPN = table.Column<string>(nullable: true),
                    baj_cZRWL = table.Column<string>(nullable: true),
                    baj_cZRWLE = table.Column<string>(nullable: true),
                    baj_cZZRWLNUM = table.Column<string>(nullable: true),
                    baj_cZZRWLENUM = table.Column<string>(nullable: true),
                    diy_theme = table.Column<string>(nullable: true),
                    baj_cColorD = table.Column<string>(nullable: true),
                    baj_cZP_KH_TYPE = table.Column<string>(nullable: true),
                    baj_cZP_CUSTOMER = table.Column<string>(nullable: true),
                    baj_c83 = table.Column<string>(nullable: true),
                    baj_c84 = table.Column<string>(nullable: true),
                    baj_c85 = table.Column<string>(nullable: true),
                    baj_c86 = table.Column<string>(nullable: true),
                    baj_c87 = table.Column<string>(nullable: true),
                    baj_c88 = table.Column<string>(nullable: true),
                    baj_c89 = table.Column<string>(nullable: true),
                    baj_c90 = table.Column<string>(nullable: true),
                    baj_c91 = table.Column<string>(nullable: true),
                    baj_c92 = table.Column<string>(nullable: true),
                    baj_c93 = table.Column<string>(nullable: true),
                    baj_c94 = table.Column<string>(nullable: true),
                    baj_c95 = table.Column<string>(nullable: true),
                    baj_c96 = table.Column<string>(nullable: true),
                    baj_c97 = table.Column<string>(nullable: true),
                    baj_c98 = table.Column<string>(nullable: true),
                    baj_c99 = table.Column<string>(nullable: true),
                    baj_c100 = table.Column<string>(nullable: true),
                    baj_c101 = table.Column<string>(nullable: true),
                    baj_c102 = table.Column<string>(nullable: true),
                    baj_c103 = table.Column<string>(nullable: true),
                    baj_c104 = table.Column<string>(nullable: true),
                    baj_c105 = table.Column<string>(nullable: true),
                    baj_c106 = table.Column<string>(nullable: true),
                    baj_c107 = table.Column<string>(nullable: true),
                    baj_c108 = table.Column<string>(nullable: true),
                    baj_c109 = table.Column<string>(nullable: true),
                    baj_c110 = table.Column<string>(nullable: true),
                    baj_c111 = table.Column<string>(nullable: true),
                    baj_c112 = table.Column<string>(nullable: true),
                    baj_c113 = table.Column<string>(nullable: true),
                    baj_c114 = table.Column<string>(nullable: true),
                    baj_c115 = table.Column<string>(nullable: true),
                    baj_c116 = table.Column<string>(nullable: true),
                    baj_c117 = table.Column<string>(nullable: true),
                    baj_c118 = table.Column<string>(nullable: true),
                    baj_c119 = table.Column<string>(nullable: true),
                    baj_c120 = table.Column<string>(nullable: true),
                    baj_c121 = table.Column<string>(nullable: true),
                    baj_c122 = table.Column<string>(nullable: true),
                    baj_c123 = table.Column<string>(nullable: true),
                    baj_c124 = table.Column<string>(nullable: true),
                    baj_c125 = table.Column<string>(nullable: true),
                    baj_c126 = table.Column<string>(nullable: true),
                    baj_c127 = table.Column<string>(nullable: true),
                    baj_c128 = table.Column<string>(nullable: true),
                    baj_c129 = table.Column<string>(nullable: true),
                    baj_c130 = table.Column<string>(nullable: true),
                    baj_c131 = table.Column<string>(nullable: true),
                    baj_c132 = table.Column<string>(nullable: true),
                    baj_c133 = table.Column<string>(nullable: true),
                    baj_c134 = table.Column<string>(nullable: true),
                    baj_c135 = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAJ_MO", x => x.baj_c02);
                });

            migrationBuilder.CreateTable(
                name: "C_WORK_DESC_T",
                columns: table => new
                {
                    LINE_NAME = table.Column<string>(nullable: false),
                    SECTION_NAME = table.Column<string>(nullable: false),
                    WORK_SECTION = table.Column<int>(nullable: false),
                    START_TIME = table.Column<string>(nullable: true),
                    END_TIME = table.Column<string>(nullable: true),
                    TARGET = table.Column<int>(nullable: true),
                    SHIFT = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_WORK_DESC_T", x => new { x.LINE_NAME, x.SECTION_NAME, x.WORK_SECTION });
                });

            migrationBuilder.CreateTable(
                name: "CourseTest3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTest3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Followers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeTest2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeTest2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeopleTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "R_STATION_REC_T",
                columns: table => new
                {
                    WORK_DATE = table.Column<string>(nullable: true),
                    WORK_SECTION = table.Column<int>(nullable: true),
                    MO_NUMBER = table.Column<string>(nullable: true),
                    MODEL_NAME = table.Column<string>(nullable: true),
                    LINE_NAME = table.Column<string>(nullable: true),
                    SECTION_NAME = table.Column<string>(nullable: true),
                    GROUP_NAME = table.Column<string>(nullable: true),
                    WIP_QTY = table.Column<int>(nullable: true),
                    PASS_QTY = table.Column<int>(nullable: true),
                    FAIL_QTY = table.Column<int>(nullable: true),
                    REPASS_QTY = table.Column<int>(nullable: true),
                    REFAIL_QTY = table.Column<int>(nullable: true),
                    ECN_PASS_QTY = table.Column<int>(nullable: true),
                    ECN_FAIL_QTY = table.Column<int>(nullable: true),
                    LAST_FLAG = table.Column<string>(nullable: true),
                    WO_NUMBER = table.Column<string>(nullable: true),
                    BIGFLAG = table.Column<string>(nullable: true),
                    SIDEFLAG = table.Column<string>(nullable: true),
                    COMPUTER = table.Column<string>(nullable: true),
                    QmesSend = table.Column<string>(nullable: true),
                    QmesSuid = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "R_WIP_TRACKING_T",
                columns: table => new
                {
                    SERIAL_NUMBER = table.Column<string>(nullable: false),
                    MO_NUMBER = table.Column<string>(nullable: true),
                    MODEL_NAME = table.Column<string>(nullable: true),
                    VERSION_CODE = table.Column<string>(nullable: true),
                    LINE_NAME = table.Column<string>(nullable: true),
                    SECTION_NAME = table.Column<string>(nullable: true),
                    GROUP_NAME = table.Column<string>(nullable: true),
                    STATION_NAME = table.Column<string>(nullable: true),
                    STATION_SEQ = table.Column<int>(nullable: true),
                    ERROR_FLAG = table.Column<string>(nullable: true),
                    IN_STATION_TIME = table.Column<DateTime>(nullable: true),
                    IN_LINE_TIME = table.Column<DateTime>(nullable: true),
                    OUT_LINE_TIME = table.Column<DateTime>(nullable: true),
                    SHIPPING_SN = table.Column<string>(nullable: true),
                    WORK_FLAG = table.Column<string>(nullable: true),
                    FINISH_FLAG = table.Column<string>(nullable: true),
                    SPECIAL_ROUTE = table.Column<string>(nullable: true),
                    PALLET_NO = table.Column<string>(nullable: true),
                    QA_NO = table.Column<string>(nullable: true),
                    QA_RESULT = table.Column<string>(nullable: true),
                    SCRAP_FLAG = table.Column<string>(nullable: true),
                    NEXT_STATION = table.Column<string>(nullable: true),
                    CUSTOMER_NO = table.Column<string>(nullable: true),
                    KEY_PART_NO = table.Column<string>(nullable: true),
                    CARTON_NO = table.Column<string>(nullable: true),
                    WARRANTY_DATE = table.Column<DateTime>(nullable: true),
                    REWORK_NO = table.Column<string>(nullable: true),
                    REPAIR_CNT = table.Column<int>(nullable: true),
                    EMP_NO = table.Column<string>(nullable: true),
                    PALLET_FULL_FLAG = table.Column<string>(nullable: true),
                    SHIP_NO = table.Column<string>(nullable: true),
                    STATUS_FLAG = table.Column<string>(nullable: true),
                    STATE_FLAG = table.Column<string>(nullable: true),
                    RMA_NO = table.Column<string>(nullable: true),
                    SW_BOM = table.Column<string>(nullable: true),
                    SHIPPING_DATE = table.Column<DateTime>(nullable: true),
                    SMT_PART_NO = table.Column<string>(nullable: true),
                    SN_LINE = table.Column<string>(nullable: true),
                    CR_FLAG = table.Column<string>(nullable: true),
                    CUSTOMER_SW = table.Column<string>(nullable: true),
                    LOCK_FLAG = table.Column<string>(nullable: true),
                    WATERPROOF = table.Column<string>(nullable: true),
                    HOLD_FLAG = table.Column<string>(nullable: true),
                    HOLD_NO = table.Column<string>(nullable: true),
                    SN_NO = table.Column<string>(nullable: true),
                    GRADE_FLAG = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_WIP_TRACKING_T", x => x.SERIAL_NUMBER);
                });

            migrationBuilder.CreateTable(
                name: "Rawdata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_TYPE = table.Column<string>(nullable: true),
                    SERIAL_NUMBER = table.Column<string>(nullable: true),
                    MO_NUMBER = table.Column<string>(nullable: true),
                    MODEL_NAME = table.Column<string>(nullable: true),
                    LINE_NAME = table.Column<string>(nullable: true),
                    GROUP_NAME = table.Column<string>(nullable: true),
                    STATION_NAME = table.Column<string>(nullable: true),
                    TEST_RESULT = table.Column<string>(nullable: true),
                    ERROR_CODE = table.Column<string>(nullable: true),
                    ERROR_DESC = table.Column<string>(nullable: true),
                    RETRY_EC = table.Column<string>(nullable: true),
                    IN_STATION_TIME = table.Column<DateTime>(nullable: false),
                    REPAIR_RESULT = table.Column<string>(nullable: true),
                    REPAIRER = table.Column<string>(nullable: true),
                    REPAIR_REASON_INFO = table.Column<string>(nullable: true),
                    REPAIR_KEYPART_INFO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rawdata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Station_information",
                columns: table => new
                {
                    wtuid = table.Column<string>(nullable: false),
                    stime = table.Column<DateTime>(nullable: true),
                    ProcessFlow = table.Column<string>(nullable: true),
                    C1 = table.Column<string>(nullable: true),
                    C2 = table.Column<string>(nullable: true),
                    C3 = table.Column<string>(nullable: true),
                    C4 = table.Column<string>(nullable: true),
                    C5 = table.Column<string>(nullable: true),
                    C6 = table.Column<string>(nullable: true),
                    C7 = table.Column<string>(nullable: true),
                    C8 = table.Column<string>(nullable: true),
                    C9 = table.Column<string>(nullable: true),
                    C10 = table.Column<string>(nullable: true),
                    C11 = table.Column<string>(nullable: true),
                    C12 = table.Column<string>(nullable: true),
                    C13 = table.Column<string>(nullable: true),
                    C14 = table.Column<string>(nullable: true),
                    C15 = table.Column<string>(nullable: true),
                    C16 = table.Column<string>(nullable: true),
                    C17 = table.Column<string>(nullable: true),
                    C18 = table.Column<string>(nullable: true),
                    C19 = table.Column<string>(nullable: true),
                    C20 = table.Column<string>(nullable: true),
                    C21 = table.Column<string>(nullable: true),
                    C22 = table.Column<string>(nullable: true),
                    C23 = table.Column<string>(nullable: true),
                    C24 = table.Column<string>(nullable: true),
                    C25 = table.Column<string>(nullable: true),
                    C26 = table.Column<string>(nullable: true),
                    C27 = table.Column<string>(nullable: true),
                    C28 = table.Column<string>(nullable: true),
                    C29 = table.Column<string>(nullable: true),
                    C30 = table.Column<string>(nullable: true),
                    C31 = table.Column<string>(nullable: true),
                    C32 = table.Column<string>(nullable: true),
                    C33 = table.Column<string>(nullable: true),
                    C34 = table.Column<string>(nullable: true),
                    C35 = table.Column<string>(nullable: true),
                    C36 = table.Column<string>(nullable: true),
                    C37 = table.Column<string>(nullable: true),
                    C38 = table.Column<string>(nullable: true),
                    C39 = table.Column<string>(nullable: true),
                    C40 = table.Column<string>(nullable: true),
                    C41 = table.Column<string>(nullable: true),
                    C42 = table.Column<string>(nullable: true),
                    C43 = table.Column<string>(nullable: true),
                    C44 = table.Column<string>(nullable: true),
                    C45 = table.Column<string>(nullable: true),
                    C46 = table.Column<string>(nullable: true),
                    C47 = table.Column<string>(nullable: true),
                    C48 = table.Column<string>(nullable: true),
                    C49 = table.Column<string>(nullable: true),
                    C50 = table.Column<string>(nullable: true),
                    C51 = table.Column<string>(nullable: true),
                    C52 = table.Column<string>(nullable: true),
                    C53 = table.Column<string>(nullable: true),
                    C54 = table.Column<string>(nullable: true),
                    C55 = table.Column<string>(nullable: true),
                    C56 = table.Column<string>(nullable: true),
                    C57 = table.Column<string>(nullable: true),
                    C58 = table.Column<string>(nullable: true),
                    C59 = table.Column<string>(nullable: true),
                    C60 = table.Column<string>(nullable: true),
                    C61 = table.Column<string>(nullable: true),
                    C62 = table.Column<string>(nullable: true),
                    C63 = table.Column<string>(nullable: true),
                    C64 = table.Column<string>(nullable: true),
                    C65 = table.Column<string>(nullable: true),
                    C66 = table.Column<string>(nullable: true),
                    C67 = table.Column<string>(nullable: true),
                    C68 = table.Column<string>(nullable: true),
                    C69 = table.Column<string>(nullable: true),
                    C70 = table.Column<string>(nullable: true),
                    C71 = table.Column<string>(nullable: true),
                    C72 = table.Column<string>(nullable: true),
                    C73 = table.Column<string>(nullable: true),
                    C74 = table.Column<string>(nullable: true),
                    C75 = table.Column<string>(nullable: true),
                    C76 = table.Column<string>(nullable: true),
                    C77 = table.Column<string>(nullable: true),
                    C78 = table.Column<string>(nullable: true),
                    C79 = table.Column<string>(nullable: true),
                    C80 = table.Column<string>(nullable: true),
                    C81 = table.Column<string>(nullable: true),
                    C82 = table.Column<string>(nullable: true),
                    C83 = table.Column<string>(nullable: true),
                    C84 = table.Column<string>(nullable: true),
                    C85 = table.Column<string>(nullable: true),
                    C86 = table.Column<string>(nullable: true),
                    C87 = table.Column<string>(nullable: true),
                    C88 = table.Column<string>(nullable: true),
                    C89 = table.Column<string>(nullable: true),
                    C90 = table.Column<string>(nullable: true),
                    C91 = table.Column<string>(nullable: true),
                    C92 = table.Column<string>(nullable: true),
                    C93 = table.Column<string>(nullable: true),
                    C94 = table.Column<string>(nullable: true),
                    C95 = table.Column<string>(nullable: true),
                    C96 = table.Column<string>(nullable: true),
                    C97 = table.Column<string>(nullable: true),
                    C98 = table.Column<string>(nullable: true),
                    C99 = table.Column<string>(nullable: true),
                    C100 = table.Column<string>(nullable: true),
                    C101 = table.Column<string>(nullable: true),
                    C102 = table.Column<string>(nullable: true),
                    C103 = table.Column<string>(nullable: true),
                    C104 = table.Column<string>(nullable: true),
                    C105 = table.Column<string>(nullable: true),
                    C106 = table.Column<string>(nullable: true),
                    C107 = table.Column<string>(nullable: true),
                    C108 = table.Column<string>(nullable: true),
                    C109 = table.Column<string>(nullable: true),
                    C110 = table.Column<string>(nullable: true),
                    C111 = table.Column<string>(nullable: true),
                    C112 = table.Column<string>(nullable: true),
                    C113 = table.Column<string>(nullable: true),
                    C114 = table.Column<string>(nullable: true),
                    C115 = table.Column<string>(nullable: true),
                    C116 = table.Column<string>(nullable: true),
                    C117 = table.Column<string>(nullable: true),
                    C118 = table.Column<string>(nullable: true),
                    C119 = table.Column<string>(nullable: true),
                    C120 = table.Column<string>(nullable: true),
                    C121 = table.Column<string>(nullable: true),
                    C122 = table.Column<string>(nullable: true),
                    C123 = table.Column<string>(nullable: true),
                    C124 = table.Column<string>(nullable: true),
                    C125 = table.Column<string>(nullable: true),
                    C126 = table.Column<string>(nullable: true),
                    C127 = table.Column<string>(nullable: true),
                    C128 = table.Column<string>(nullable: true),
                    C129 = table.Column<string>(nullable: true),
                    C130 = table.Column<string>(nullable: true),
                    C131 = table.Column<string>(nullable: true),
                    C132 = table.Column<string>(nullable: true),
                    C133 = table.Column<string>(nullable: true),
                    C134 = table.Column<string>(nullable: true),
                    C135 = table.Column<string>(nullable: true),
                    C136 = table.Column<string>(nullable: true),
                    C137 = table.Column<string>(nullable: true),
                    C138 = table.Column<string>(nullable: true),
                    C139 = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    RR = table.Column<int>(nullable: false),
                    RE = table.Column<int>(nullable: false),
                    RW = table.Column<int>(nullable: false),
                    PtintTime = table.Column<string>(nullable: true),
                    BigSN = table.Column<string>(nullable: true),
                    SN = table.Column<string>(nullable: true),
                    IMEI = table.Column<string>(nullable: true),
                    C140 = table.Column<string>(nullable: true),
                    C141 = table.Column<string>(nullable: true),
                    C142 = table.Column<string>(nullable: true),
                    C143 = table.Column<string>(nullable: true),
                    C144 = table.Column<string>(nullable: true),
                    C145 = table.Column<string>(nullable: true),
                    C146 = table.Column<string>(nullable: true),
                    C147 = table.Column<string>(nullable: true),
                    C148 = table.Column<string>(nullable: true),
                    C149 = table.Column<string>(nullable: true),
                    C150 = table.Column<string>(nullable: true),
                    C151 = table.Column<string>(nullable: true),
                    C152 = table.Column<string>(nullable: true),
                    C153 = table.Column<string>(nullable: true),
                    C154 = table.Column<string>(nullable: true),
                    C155 = table.Column<string>(nullable: true),
                    C156 = table.Column<string>(nullable: true),
                    C157 = table.Column<string>(nullable: true),
                    C158 = table.Column<string>(nullable: true),
                    C159 = table.Column<string>(nullable: true),
                    C160 = table.Column<string>(nullable: true),
                    C161 = table.Column<string>(nullable: true),
                    C162 = table.Column<string>(nullable: true),
                    C163 = table.Column<string>(nullable: true),
                    C164 = table.Column<string>(nullable: true),
                    C165 = table.Column<string>(nullable: true),
                    C166 = table.Column<string>(nullable: true),
                    C167 = table.Column<string>(nullable: true),
                    C168 = table.Column<string>(nullable: true),
                    C169 = table.Column<string>(nullable: true),
                    C170 = table.Column<string>(nullable: true),
                    C171 = table.Column<string>(nullable: true),
                    C172 = table.Column<string>(nullable: true),
                    C173 = table.Column<string>(nullable: true),
                    C174 = table.Column<string>(nullable: true),
                    C175 = table.Column<string>(nullable: true),
                    C176 = table.Column<string>(nullable: true),
                    C177 = table.Column<string>(nullable: true),
                    C178 = table.Column<string>(nullable: true),
                    C179 = table.Column<string>(nullable: true),
                    C180 = table.Column<string>(nullable: true),
                    C181 = table.Column<string>(nullable: true),
                    C182 = table.Column<string>(nullable: true),
                    C183 = table.Column<string>(nullable: true),
                    C184 = table.Column<string>(nullable: true),
                    C185 = table.Column<string>(nullable: true),
                    C186 = table.Column<string>(nullable: true),
                    C187 = table.Column<string>(nullable: true),
                    C188 = table.Column<string>(nullable: true),
                    C189 = table.Column<string>(nullable: true),
                    C190 = table.Column<string>(nullable: true),
                    C191 = table.Column<string>(nullable: true),
                    C192 = table.Column<string>(nullable: true),
                    C193 = table.Column<string>(nullable: true),
                    C194 = table.Column<string>(nullable: true),
                    C195 = table.Column<string>(nullable: true),
                    C196 = table.Column<string>(nullable: true),
                    C197 = table.Column<string>(nullable: true),
                    C198 = table.Column<string>(nullable: true),
                    C199 = table.Column<string>(nullable: true),
                    C200 = table.Column<string>(nullable: true),
                    C201 = table.Column<string>(nullable: true),
                    C202 = table.Column<string>(nullable: true),
                    C203 = table.Column<string>(nullable: true),
                    C204 = table.Column<string>(nullable: true),
                    C205 = table.Column<string>(nullable: true),
                    C206 = table.Column<string>(nullable: true),
                    C207 = table.Column<string>(nullable: true),
                    C208 = table.Column<string>(nullable: true),
                    C209 = table.Column<string>(nullable: true),
                    C210 = table.Column<string>(nullable: true),
                    C211 = table.Column<string>(nullable: true),
                    C212 = table.Column<string>(nullable: true),
                    C213 = table.Column<string>(nullable: true),
                    C214 = table.Column<string>(nullable: true),
                    C215 = table.Column<string>(nullable: true),
                    C216 = table.Column<string>(nullable: true),
                    C217 = table.Column<string>(nullable: true),
                    C218 = table.Column<string>(nullable: true),
                    C219 = table.Column<string>(nullable: true),
                    C220 = table.Column<string>(nullable: true),
                    C221 = table.Column<string>(nullable: true),
                    C222 = table.Column<string>(nullable: true),
                    C223 = table.Column<string>(nullable: true),
                    C224 = table.Column<string>(nullable: true),
                    C225 = table.Column<string>(nullable: true),
                    C226 = table.Column<string>(nullable: true),
                    C227 = table.Column<string>(nullable: true),
                    C228 = table.Column<string>(nullable: true),
                    C229 = table.Column<string>(nullable: true),
                    C230 = table.Column<string>(nullable: true),
                    C231 = table.Column<string>(nullable: true),
                    C232 = table.Column<string>(nullable: true),
                    C233 = table.Column<string>(nullable: true),
                    C234 = table.Column<string>(nullable: true),
                    C235 = table.Column<string>(nullable: true),
                    C236 = table.Column<string>(nullable: true),
                    C237 = table.Column<string>(nullable: true),
                    C238 = table.Column<string>(nullable: true),
                    C239 = table.Column<string>(nullable: true),
                    C240 = table.Column<string>(nullable: true),
                    C241 = table.Column<string>(nullable: true),
                    C242 = table.Column<string>(nullable: true),
                    C243 = table.Column<string>(nullable: true),
                    C244 = table.Column<string>(nullable: true),
                    C245 = table.Column<string>(nullable: true),
                    C246 = table.Column<string>(nullable: true),
                    C247 = table.Column<string>(nullable: true),
                    C248 = table.Column<string>(nullable: true),
                    C249 = table.Column<string>(nullable: true),
                    C250 = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station_information", x => x.wtuid);
                });

            migrationBuilder.CreateTable(
                name: "StationResume",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    PSN = table.Column<string>(nullable: true),
                    StationID = table.Column<string>(nullable: true),
                    StationName = table.Column<string>(nullable: true),
                    testFlag = table.Column<string>(nullable: true),
                    testLine = table.Column<string>(nullable: true),
                    testWorkorder = table.Column<string>(nullable: true),
                    testModel = table.Column<string>(nullable: true),
                    testType = table.Column<string>(nullable: true),
                    testTime = table.Column<DateTime>(nullable: false),
                    testAddress = table.Column<string>(nullable: true),
                    testWorkID = table.Column<string>(nullable: true),
                    testInformation = table.Column<string>(nullable: true),
                    testRec1 = table.Column<string>(nullable: true),
                    testRec2 = table.Column<string>(nullable: true),
                    testRec3 = table.Column<string>(nullable: true),
                    testRec4 = table.Column<string>(nullable: true),
                    testRec5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationResume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationResume_Fail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    PSN = table.Column<string>(nullable: true),
                    StationID = table.Column<string>(nullable: true),
                    StationName = table.Column<string>(nullable: true),
                    testFlag = table.Column<string>(nullable: true),
                    testLine = table.Column<string>(nullable: true),
                    testWorkorder = table.Column<string>(nullable: true),
                    testModel = table.Column<string>(nullable: true),
                    testType = table.Column<string>(nullable: true),
                    testTime = table.Column<DateTime>(nullable: false),
                    testAddress = table.Column<string>(nullable: true),
                    testWorkID = table.Column<string>(nullable: true),
                    testInformation = table.Column<string>(nullable: true),
                    testRec1 = table.Column<string>(nullable: true),
                    testRec2 = table.Column<string>(nullable: true),
                    testRec3 = table.Column<string>(nullable: true),
                    testRec4 = table.Column<string>(nullable: true),
                    testRec5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationResume_Fail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTest3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false),
                    Roll = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Class = table.Column<int>(nullable: false),
                    Section = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WriteNumber",
                columns: table => new
                {
                    PcbSN = table.Column<string>(nullable: false),
                    Imei_1 = table.Column<string>(nullable: true),
                    Imei_2 = table.Column<string>(nullable: true),
                    Imei_3 = table.Column<string>(nullable: true),
                    Imei_4 = table.Column<string>(nullable: true),
                    BtMac = table.Column<string>(nullable: true),
                    WifiMac = table.Column<string>(nullable: true),
                    NetCode = table.Column<string>(nullable: true),
                    FpSN = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    FpOrderNumber = table.Column<string>(nullable: true),
                    PcbSNWriteTime = table.Column<DateTime>(nullable: false),
                    IMEIWriteTime = table.Column<DateTime>(nullable: true),
                    WritePcbSNAddress = table.Column<string>(nullable: true),
                    WriteIMEIAddress = table.Column<string>(nullable: true),
                    CustomizeSN = table.Column<string>(nullable: true),
                    MEID = table.Column<string>(nullable: true),
                    ID2 = table.Column<long>(nullable: false),
                    Wifi2Mac = table.Column<string>(nullable: true),
                    LanMac = table.Column<string>(nullable: true),
                    Wifi3Mac = table.Column<string>(nullable: true),
                    Wifi4Mac = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteNumber", x => x.PcbSN);
                });

            migrationBuilder.CreateTable(
                name: "StudentTest2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GradeTest2Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTest2s_GradeTest2s_GradeTest2Id",
                        column: x => x.GradeTest2Id,
                        principalTable: "GradeTest2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumeDetailTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumeType = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    PeopleTestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumeDetailTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumeDetailTests_PeopleTests_PeopleTestId",
                        column: x => x.PeopleTestId,
                        principalTable: "PeopleTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse3",
                columns: table => new
                {
                    StudentTest3Id = table.Column<int>(nullable: false),
                    CourseTest3Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse3", x => new { x.StudentTest3Id, x.CourseTest3Id });
                    table.ForeignKey(
                        name: "FK_StudentCourse3_CourseTest3_CourseTest3Id",
                        column: x => x.CourseTest3Id,
                        principalTable: "CourseTest3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse3_StudentTest3_StudentTest3Id",
                        column: x => x.StudentTest3Id,
                        principalTable: "StudentTest3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumeDetailTests_PeopleTestId",
                table: "ConsumeDetailTests",
                column: "PeopleTestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse3_CourseTest3Id",
                table: "StudentCourse3",
                column: "CourseTest3Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest2s_GradeTest2Id",
                table: "StudentTest2s",
                column: "GradeTest2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoRepairStation");

            migrationBuilder.DropTable(
                name: "BAH_MOProcessFlow");

            migrationBuilder.DropTable(
                name: "BAJ_MO");

            migrationBuilder.DropTable(
                name: "C_WORK_DESC_T");

            migrationBuilder.DropTable(
                name: "ConsumeDetailTests");

            migrationBuilder.DropTable(
                name: "DeveloperTests");

            migrationBuilder.DropTable(
                name: "R_STATION_REC_T");

            migrationBuilder.DropTable(
                name: "R_WIP_TRACKING_T");

            migrationBuilder.DropTable(
                name: "Rawdata");

            migrationBuilder.DropTable(
                name: "Station_information");

            migrationBuilder.DropTable(
                name: "StationResume");

            migrationBuilder.DropTable(
                name: "StationResume_Fail");

            migrationBuilder.DropTable(
                name: "StudentCourse3");

            migrationBuilder.DropTable(
                name: "StudentTest2s");

            migrationBuilder.DropTable(
                name: "StudentTests");

            migrationBuilder.DropTable(
                name: "WriteNumber");

            migrationBuilder.DropTable(
                name: "PeopleTests");

            migrationBuilder.DropTable(
                name: "CourseTest3");

            migrationBuilder.DropTable(
                name: "StudentTest3");

            migrationBuilder.DropTable(
                name: "GradeTest2s");
        }
    }
}

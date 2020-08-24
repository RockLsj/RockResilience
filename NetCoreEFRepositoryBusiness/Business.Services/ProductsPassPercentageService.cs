using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Domain.Entities;
using Business.EntityFrameworkCore.UnitOfWorks;

namespace Business.Services
{
    public class ProductsPassPercentageService
    {
        public IUnitOfWork UnitOfWork
        {
            get;
            set;
        }

        private void a1()
        {
            string GUID = Guid.NewGuid().ToString();
            string Wdatetime = DateTime.Now.ToString("yyyy-MM:dd HH:mm:ss");
        }

        private string a2(string Flag)
        {
            Flag = Flag.ToLower();
            if (Flag == "pass" || Flag == "ok")
            {
                Flag = "P";
            }
            if (Flag == "fail" || Flag == "ng")
            {
                Flag = "F";
            }
            if (Flag == "good")
            {
                Flag = "G";
            }
            if (Flag == "input")
            {
                Flag = "I";
            }
            if (Flag == "output")
            {
                Flag = "O";
            }
            if (Flag == "rework")
            {
                Flag = "R";
            }
            return Flag;
        }

        private void a3(string Wdatetime)
        {
            int Work_Section = 0;

            string Date = DateTime.Now.ToString("yyyyMMdd");

            if (string.IsNullOrEmpty(Wdatetime) == true)
            {
                Wdatetime = DateTime.Now.ToString("hh:mm");
            }
            Work_Section = a4();
        }

        private int a4()
        {
            int Work_Section = UnitOfWork.C_WORK_DESC_Ts.Spd_Get_WorkSection();
            return Work_Section;

        }

        private int a5(string Flag, string strType)
        {
            int nResult = 0;
            if (Flag != "F" && Flag != "P" && Flag != "G" && Flag != "I" && Flag != "O" && Flag != "R")
            {
                nResult = -1;
            }
            if (strType != "0" && strType != "1" && strType != "2" && strType != "3")
            {

                nResult = -2;
            }
            return nResult;
        }

        private bool a6(string IMEI,
            out string SN,
            out int nResult)
        {
            bool bFlag = false;

            SN = "";
            nResult = 0;

            if (string.IsNullOrEmpty(SN))
            {
                if (string.IsNullOrEmpty(IMEI))
                {
                    nResult = -3;
                    bFlag = false;
                }
                else
                {
                    try
                    {
                        SN = UnitOfWork.WriteNumbers.GetPcbSN(IMEI);
                        bFlag = true;
                    }
                    catch
                    {
                        nResult = -4;
                        bFlag = false;
                    }
                }
            }

            return bFlag;
        }

        private void a7(string P3, string Customer, string SN,
            string StationID, string StationName, string Flag,
            string Line, string OrdId, string Model,
            string strType, string Computer, string P1,
            string P2, string P4, string IssueDescription,
            string P5, string P6, string P7)
        {
            StationResume e = new StationResume();

            e.GUID = P3;
            e.Customer = Customer;
            e.PSN = SN;
            e.StationID = StationID;
            e.StationName = StationName;
            e.testFlag = Flag;
            e.testLine = Line;
            e.testWorkorder = OrdId;
            e.testModel = Model;
            e.testType = strType;
            e.testAddress = Computer;
            e.testWorkID = P1;
            e.testInformation = P2;
            e.testRec1 = P4;
            e.testRec2 = IssueDescription;
            e.testRec3 = P5;
            e.testRec4 = P6;
            e.testRec5 = P7;

            UnitOfWork.StationResumes.AddStationResume(e);
        }

        private void a8(string P3, string Customer, string SN,
            string StationID, string StationName, string Flag,
            string Line, string OrdId, string Model,
            string strType, string Computer, string P1,
            string P2, string P4, string IssueDescription,
            string P5, string P6, string P7)
        {
            if (Flag == "F" && strType == "0")
            {
                StationResume_Fail e = new StationResume_Fail();

                e.GUID = P3;
                e.Customer = Customer;
                e.PSN = SN;
                e.StationID = StationID;
                e.StationName = StationName;
                e.testFlag = Flag;
                e.testLine = Line;
                e.testWorkorder = OrdId;
                e.testModel = Model;
                e.testType = strType;
                e.testAddress = Computer;
                e.testWorkID = P1;
                e.testInformation = P2;
                e.testRec1 = P4;
                e.testRec2 = IssueDescription;
                e.testRec3 = P5;
                e.testRec4 = P6;
                e.testRec5 = P7;

                UnitOfWork.StationResume_Fails.AddStationResume_Fail(e);
            }
        }

        private void a9(string LINE_NAME, string WORK_DATE, string GROUP_NAME, string MO_NUMBER, int WORK_SECTION,
            string Model)
        {
            bool bExist = UnitOfWork.R_STATION_REC_Ts.IsExistLINE_NAME(LINE_NAME, WORK_DATE, GROUP_NAME, MO_NUMBER, WORK_SECTION);
            if (bExist == false)
            {
                UnitOfWork.R_STATION_REC_Ts.AddR_STATION_REC_T(WORK_DATE,
                    LINE_NAME,
                    GROUP_NAME,
                    Model,
                    MO_NUMBER,
                    0,
                    0,
                    0,
                    0,
                    0,
                    WORK_SECTION,
                    MO_NUMBER);
            }
        }

        private string a10(string IssueDescription, string Flag, string StationName)
        {
            if (IssueDescription.Length == 0 && Flag == "F")
            {
                IssueDescription = StationName + "_Fail";
            }
            return IssueDescription;
        }

        private bool a11(string SN, string Model,
            out int nCode)
        {
            bool bFlag = false;

            nCode = 0;

            bool bIsExist = UnitOfWork.Station_informations.IsExistwtuid(SN);
            if (bIsExist == false)
            {
                try
                {
                    UnitOfWork.Station_informations.AddStation_information(SN, Model);
                    bFlag = true;
                }
                catch
                {
                    bFlag = false;
                    nCode = -96;
                }
            }

            return bFlag;
        }

        private void a12(string strType, string Flag, string SN,
            string StationID,
            out int nCode)
        {
            nCode = 0;

            if (strType == "1" || strType == "2" || strType == "3")
            {
                a13(strType, Flag, SN, out nCode);
                a14(strType, Flag, SN, StationID, out nCode);
                a15(strType, Flag, SN, StationID, out nCode);
            }
        }

        private void a16()
        {

        }

        private bool a13(string strType, string Flag,
            string SN,
            out int nCode)
        {
            bool bFlag = false;

            nCode = 0;

            if (strType == "1" && Flag == "I")
            {
                int RR = 2;
                try
                {
                    UnitOfWork.Station_informations.UpdateStation_information(SN, RR);
                    bFlag = true;
                }
                catch
                {
                    bFlag = false;
                }
            }

            return bFlag;
        }

        private bool a14(string strType, string Flag,
            string SN, string StationID,
            out int nCode)
        {
            bool bFlag = false;

            nCode = 0;

            if (strType == "2" && Flag == "R")
            {
                StationID = StationID.Trim();
                string strSql = "UPDATE Station_information SET RR=1,RE=RE+1,C" + StationID + "=ISNULL(C" + StationID + ",'''')+''/'' WHERE wtuid=''" + SN + "''";
                bFlag = UnitOfWork.Station_informations.UpdateStation_information(strSql);

                nCode = -92;
            }

            return bFlag;
        }

        private bool a15(string strType, string Flag,
            string SN, string StationID,
            out int nCode)
        {
            bool bFlag = false;

            nCode = 0;

            if (strType == "3" && Flag == "O")
            {
                bFlag = a14(strType, Flag,
                    SN, StationID,
                    out nCode);
                if (!bFlag)
                {
                    nCode = -93;
                }
            }

            return bFlag;
        }

        private bool a16(string strType, string SN, string Flag, string StationID,
            out int nCode)
        {
            bool bFlag = false;

            nCode = 0;

            StationID = StationID.Trim();
            string strSql = "UPDATE Station_information SET C" + StationID + "=ISNULL(C" + StationID + ",'''')+''" + Flag + "'' WHERE wtuid=''" + SN + "''";
            try
            {
                bFlag = UnitOfWork.Station_informations.UpdateStation_information(strSql);
            }
            catch
            {
                bFlag = false;
                nCode = -94;
            }

            return bFlag;
        }

        private bool a17(string StationID, string SN,
            out int nCode,
            out string strStationFlag)
        {
            bool bFlag = false;

            nCode = 0;
            strStationFlag = "";

            try
            {
                string strSql = "SELECT C" + StationID + " FROM Station_information with(NOLOCK) WHERE wtuid=''" + SN + "''";
                strStationFlag = UnitOfWork.Station_informations.GetStationFlag(strSql);
                bFlag = true;
            }
            catch
            {
                bFlag = false;
                nCode = -95;
            }

            return bFlag;
        }

        private string a18(string bah_c13, string bah_c031)
        {
            string BadF = "";

            int BadNub = UnitOfWork.BAH_MOProcessFlows.GetBah_n11(bah_c13, bah_c031);

            if (BadNub == 0)
            {
                BadNub = 3;
            }
            if (BadNub == 1)
            {
                BadF = "F";
            }
            if (BadNub == 2)
            {
                BadF = "FF";
            }
            if (BadNub == 3)
            {
                BadF = "FFF";
            }

            return BadF;
        }

        public void Testing()
        {
            int nTest = UnitOfWork.C_WORK_DESC_Ts.Spd_Get_WorkSection();
        }

    }
}

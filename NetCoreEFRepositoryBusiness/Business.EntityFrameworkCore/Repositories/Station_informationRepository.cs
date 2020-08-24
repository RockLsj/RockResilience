using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Common.Extensions;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;
using Business.EntityFrameworkCore.Repositories.Interfaces;

namespace Business.EntityFrameworkCore.Repositories
{
    public class Station_informationRepository :
        BaseRepository<ApplicationContext, Station_information, int>,
        IStation_informationRepository
    {
        public Station_informationRepository(ApplicationContext context) : base(context)
        {

        }

        public bool IsExistwtuid(string SN)
        {
            string wtuid = "";

            Expression<Func<Station_information, bool>> predicate = f => true;
            predicate = predicate.And(e => e.wtuid == SN);

            var iq = base.Load(predicate);

            if (iq.Any())
            {
                wtuid = iq.Select(e => e.wtuid).FirstOrDefault();
            }

            return !String.IsNullOrEmpty(wtuid);
        }

        public void AddStation_information(string wtuid, string Model)
        {
            Station_information e = new Station_information();
            e.wtuid = wtuid;
            e.Model = Model;

            base.Insert(e);
        }

        public void UpdateStation_information(string wtuid, int RR)
        {
            Station_information e = new Station_information();
            e.wtuid = wtuid;
            e.RR = RR;

            base.Update(e);
        }

        public bool UpdateStation_information(string strSql)
        {
            bool bFlag = false;

            try
            {
                base.ExecuteSql(strSql);

                bFlag = true;
            }
            catch
            {
                bFlag = false;
            }

            return bFlag;
        }

        public string GetStationFlag(string strSql)
        {
            string strStationFlag = ""; ;
            DataTable dt = base.GetDataTableWithSql(strSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                strStationFlag = dt.Rows[0][0].ToString();
            }
            return strStationFlag;
        }
    }
}

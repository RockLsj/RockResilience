using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Common.Extensions;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;
using Business.EntityFrameworkCore.Repositories.Interfaces;

namespace Business.EntityFrameworkCore.Repositories
{
    public class WriteNumberRepository :
        BaseRepository<ApplicationContext, WriteNumber, int>,
        IWriteNumberRepository
    {
        public WriteNumberRepository(ApplicationContext context) : base(context)
        {

        }

        public string GetPcbSN(string Imei_1)
        {
            string SN = "";

            Expression<Func<WriteNumber, bool>> predicate = f => true;
            predicate = predicate.And(e=> e.Imei_1== Imei_1);

            var iq = base.Load(predicate);

            if (iq.Any())
            {
                SN = iq.Select(e => e.PcbSN).FirstOrDefault();
            }

            return SN;
        }
    }
}

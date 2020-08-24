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
    public class BAH_MOProcessFlowRepository :
        BaseRepository<ApplicationContext, BAH_MOProcessFlow, int>,
        IBAH_MOProcessFlowRepository
    {
        public BAH_MOProcessFlowRepository(ApplicationContext context) : base(context)
        {

        }

        public int GetBah_n11(string bah_c13, string bah_c031)
        {
            int BadNub=0;

            Expression<Func<BAH_MOProcessFlow, bool>> predicate = f => true;
            predicate = predicate.And(e => e.bah_c13 == bah_c13);
            predicate = predicate.And(e => e.bah_c031 == bah_c031);

            var iq = base.Load(predicate);

            if (iq.Any())
            {
                BadNub = iq.Select(e => e.bah_n11).FirstOrDefault();
            }

            return BadNub;
        }
    }
}

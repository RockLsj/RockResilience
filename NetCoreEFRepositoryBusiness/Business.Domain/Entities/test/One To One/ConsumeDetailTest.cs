using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class ConsumeDetailTest : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// 1:Breakfast
        /// 2:Noon meal
        /// 3:Night meal
        /// 4:Shopping
        /// </summary>
        public int ConsumeType { get; set; }

        public double TotalPrice { get; set; }

        public int PeopleTestId { get; set; }
        public virtual PeopleTest PeopleTest { get; set; }
    }
}

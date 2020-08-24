using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class C_WORK_DESC_T : IEntity
    {
        public string LINE_NAME { get; set; }
        public string SECTION_NAME { get; set; }
        public int WORK_SECTION { get; set; }

        //原来为string
        //现在修改为int
        public int START_TIME { get; set; }
        //原来为string
        //现在修改为int
        public int END_TIME { get; set; }
        public Nullable<int> TARGET { get; set; }
        public Nullable<int> SHIFT { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}

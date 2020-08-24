using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class BAH_MOProcessFlow : IEntity
    {
        public int bah_c02 { get; set; }
        public int bah_c03 { get; set; }
        public string bah_c031 { get; set; }
        public string bah_c04 { get; set; }
        public int bah_c05 { get; set; }
        public int bah_c06 { get; set; }
        public string bah_c07 { get; set; }
        public string bah_c08 { get; set; }
        public string bah_c09 { get; set; }
        public string bah_c10 { get; set; }
        public int bah_n11 { get; set; }
        public string bah_c12 { get; set; }
        public string bah_c13 { get; set; }
        public string bah_cCreateUser { get; set; }
        public Nullable<System.DateTime> bah_dCreateDate { get; set; }
        public Nullable<System.DateTime> bah_dLastUpdateDate { get; set; }
        public string bah_cLastUpdateUser { get; set; }
        public string bah_cCustID { get; set; }
        public string bah_cConfirmUser { get; set; }
        public Nullable<System.DateTime> bah_dConfirmDate { get; set; }
        public string bah_cState { get; set; }
        public string bah_cValid { get; set; }
        public int bah_n12 { get; set; }
        public string bah_c14 { get; set; }
        public string bah_nEdition { get; set; }
        public string bah_nConfig { get; set; }
        public decimal bah_cTimeoutControl { get; set; }
        public string bah_cdescribe { get; set; }
        public Nullable<decimal> bah_cMinTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}

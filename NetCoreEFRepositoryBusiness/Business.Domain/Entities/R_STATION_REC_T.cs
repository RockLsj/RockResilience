using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class R_STATION_REC_T : IEntity
    {
        public string WORK_DATE { get; set; }
        public Nullable<int> WORK_SECTION { get; set; }
        public string MO_NUMBER { get; set; }
        public string MODEL_NAME { get; set; }
        public string LINE_NAME { get; set; }
        public string SECTION_NAME { get; set; }
        public string GROUP_NAME { get; set; }
        public Nullable<int> WIP_QTY { get; set; }
        public Nullable<int> PASS_QTY { get; set; }
        public Nullable<int> FAIL_QTY { get; set; }
        public Nullable<int> REPASS_QTY { get; set; }
        public Nullable<int> REFAIL_QTY { get; set; }
        public Nullable<int> ECN_PASS_QTY { get; set; }
        public Nullable<int> ECN_FAIL_QTY { get; set; }
        public string LAST_FLAG { get; set; }
        public string WO_NUMBER { get; set; }
        public string BIGFLAG { get; set; }
        public string SIDEFLAG { get; set; }
        public string COMPUTER { get; set; }
        public string QmesSend { get; set; }
        public string QmesSuid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class Rawdata : IEntity
    {
        public string DATA_TYPE { get; set; }
        public string SERIAL_NUMBER { get; set; }
        public string MO_NUMBER { get; set; }
        public string MODEL_NAME { get; set; }
        public string LINE_NAME { get; set; }
        public string GROUP_NAME { get; set; }
        public string STATION_NAME { get; set; }
        public string TEST_RESULT { get; set; }
        public string ERROR_CODE { get; set; }
        public string ERROR_DESC { get; set; }
        public string RETRY_EC { get; set; }
        public System.DateTime IN_STATION_TIME { get; set; }
        public string REPAIR_RESULT { get; set; }
        public string REPAIRER { get; set; }
        public string REPAIR_REASON_INFO { get; set; }
        public string REPAIR_KEYPART_INFO { get; set; }

        //原来主键为：ISID
        //现在修改为Id
        [Key]
        public int Id { get; set; }
    }
}

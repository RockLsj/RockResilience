using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class WriteNumber : IEntity
    {
        [Key]
        public string PcbSN { get; set; }
        public string Imei_1 { get; set; }
        public string Imei_2 { get; set; }
        public string Imei_3 { get; set; }
        public string Imei_4 { get; set; }
        public string BtMac { get; set; }
        public string WifiMac { get; set; }
        public string NetCode { get; set; }
        public string FpSN { get; set; }
        public string OrderNumber { get; set; }
        public string FpOrderNumber { get; set; }
        public System.DateTime PcbSNWriteTime { get; set; }
        public Nullable<System.DateTime> IMEIWriteTime { get; set; }
        public string WritePcbSNAddress { get; set; }
        public string WriteIMEIAddress { get; set; }
        public string CustomizeSN { get; set; }
        public string MEID { get; set; }
        //原来为ID，现在将其修改为ID2
        public long ID2 { get; set; }
        public string Wifi2Mac { get; set; }
        public string LanMac { get; set; }
        public string Wifi3Mac { get; set; }
        public string Wifi4Mac { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}

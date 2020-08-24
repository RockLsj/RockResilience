using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.DTO.Rsp
{
    public class TestObjRsp
    {
        public int Id { get; set; }
        public string IDNumber { get; set; }
        public int ConsumeType { get; set; }
        public double TotalPrice { get; set; }
    }
}

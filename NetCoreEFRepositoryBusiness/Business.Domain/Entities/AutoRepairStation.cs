using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class AutoRepairStation:IEntity
    {
        public string StationName { get; set; }

        //原来主键为：StationID
        //现在修改为Id
        [Key]
        public int Id { get; set; }
    }
}

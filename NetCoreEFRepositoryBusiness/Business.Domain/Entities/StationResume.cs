using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class StationResume : IEntity
    {
        public string GUID { get; set; }
        public string Customer { get; set; }
        public string PSN { get; set; }
        public string StationID { get; set; }
        public string StationName { get; set; }
        public string testFlag { get; set; }
        public string testLine { get; set; }
        public string testWorkorder { get; set; }
        public string testModel { get; set; }
        public string testType { get; set; }
        public System.DateTime testTime { get; set; }
        public string testAddress { get; set; }
        public string testWorkID { get; set; }
        public string testInformation { get; set; }
        public string testRec1 { get; set; }
        public string testRec2 { get; set; }
        public string testRec3 { get; set; }
        public string testRec4 { get; set; }
        public string testRec5 { get; set; }

        //原来主键为：ISID
        //现在修改为Id
        [Key]
        public int Id { get; set; }
    }
}

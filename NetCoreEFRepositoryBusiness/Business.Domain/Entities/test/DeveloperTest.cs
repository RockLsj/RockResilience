using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class DeveloperTest : IEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public int Followers { get; set; }

        public int Id { get; set; }
    }
}

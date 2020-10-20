using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class DeveloperTest : IEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public int Followers { get; set; }

        [JsonIgnore]
        public int Id { get; set; }
    }
}

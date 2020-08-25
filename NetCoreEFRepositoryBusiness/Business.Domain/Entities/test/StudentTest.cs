using System.ComponentModel.DataAnnotations;

using Common.Domain.Entities;
 
namespace Business.Domain.Entities
{
    public class StudentTest : IEntity
    {
        public int Age { get; set; }

        public int Roll { get; set; }

        public string Name { get; set; }

        public int Class { get; set; }

        [MaxLength(50)]
        public string Section { get; set; }

        public int Id { get; set; }
    }
}

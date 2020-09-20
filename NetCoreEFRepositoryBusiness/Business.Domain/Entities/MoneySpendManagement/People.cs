using Common.Domain.Entities;
using Common.FieldValidation;
using System.ComponentModel.DataAnnotations;

namespace Business.Domain.Entities
{
    public class People : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [Range(1, 200)]
        public int Age { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 18)]
        [CurrencyCode("420325198612121515")]
        public string IDNumber { get; set; }
    }
}

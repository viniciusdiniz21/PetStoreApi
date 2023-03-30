using System.ComponentModel.DataAnnotations;

namespace PetStore.Entities
{
    public class ProductEntity
    {
        [Key]
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

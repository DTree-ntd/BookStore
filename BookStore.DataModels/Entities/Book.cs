using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataModels.Entities
{
    public class Book
    {
        public Book()
        {
            Stores = new HashSet<Store>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Quantity { set; get; }
        [Required]
        public decimal Price { set; get; }

        public int AuthorId { set; get; }
        [ForeignKey("AuthorId")]
        public Author Author { set; get; }

        public ICollection<Store> Stores { get; set; }
    }
}

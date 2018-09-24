namespace Application.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Value
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}

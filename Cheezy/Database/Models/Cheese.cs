using Cheezy.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cheezy.Database.Models
{
    public class Cheese
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public Taste Taste { get; set; }
    }
}

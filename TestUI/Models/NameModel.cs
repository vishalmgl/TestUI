using System.ComponentModel.DataAnnotations;

namespace Test2UI.Models
{
    public class NameModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        public string City { get; set; }
    }
}

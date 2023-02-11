using System.ComponentModel.DataAnnotations;

namespace Transportation.API.Models
{
    public class Car
    {
        public int Id { get; set; }
        
        [Required]
        public string Make { get; set; }

        [Required]
        public string Number { get; set; }
        

    }
}

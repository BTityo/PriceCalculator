using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceCalculator.DAL.Models
{
    [Table("Piece", Schema = "Constant")]
    public class Piece : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public byte Value { get; set; }


        public virtual ICollection<Calculation> Calculations { get; set; }
    }
}

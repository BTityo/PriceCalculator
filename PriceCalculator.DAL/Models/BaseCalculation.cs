using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceCalculator.DAL.Models
{
    [Table("BaseCalculation", Schema = "Material")]
    public class BaseCalculation : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal WithoutTaxSum { get; set; }

        [Required]
        public decimal WithTaxSum { get; set; }

        public virtual ICollection<Calculation> Calculations { get; set; }
    }
}

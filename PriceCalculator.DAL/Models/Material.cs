using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceCalculator.DAL.Models
{
    [Table("Material", Schema = "Material")]
    public class Material : BaseModel
    {
        [Required, DisplayName("Anyag neve")]
        public string Name { get; set; }

        [Required, DisplayName("Két cm"), DefaultValue(0)]
        public decimal TwoCM { get; set; }

        [Required, DisplayName("Három cm"), DefaultValue(0)]
        public decimal ThreeCM { get; set; }

        [Required, DisplayName("Öt cm"), DefaultValue(0)]
        public decimal FiveCM { get; set; }

        [Required, DisplayName("Nyolc cm"), DefaultValue(0)]
        public decimal EightCM { get; set; }

        [Required, DisplayName("Kilenc cm"), DefaultValue(0)]
        public decimal NineCM { get; set; }

        [Required, DisplayName("Tíz cm"), DefaultValue(0)]
        public decimal TenCM { get; set; }


        public ICollection<Calculation> Calculations { get; set; }
    }
}

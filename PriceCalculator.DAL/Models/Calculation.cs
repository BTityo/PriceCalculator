using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceCalculator.DAL.Models
{
    [Table("Calculation", Schema = "Material")]
    public class Calculation : BaseModel
    {
        [Required]
        public ushort Length { get; set; }

        [Required]
        public ushort Width { get; set; }

        [Required]
        public int SquareMeter { get { return Length * Width * Piece.Value / 10000; } }

        [Required]
        public decimal ItemPrice
        {
            get
            {
                double multiplier = (Thickness.Value > 4) ? 1.3 : 1.4;

                return (decimal)multiplier * getSelectedPriceByThickness() * SquareMeter;
            }
        }

        private decimal getSelectedPriceByThickness()
        {
            switch (Thickness.Value)
            {
                case 2:
                    return Material.TwoCM;
                case 3:
                    return Material.ThreeCM;
                case 5:
                    return Material.FiveCM;
                case 8:
                    return Material.EightCM;
                case 9:
                    return Material.NineCM;
                case 10:
                    return Material.TenCM;
                default:
                    return 0;
            }
        }


        [Required]
        public int PieceId { get; set; }
        public virtual Piece Piece { get; set; }

        [Required]
        public int ThicknessId { get; set; }
        public virtual Thickness Thickness { get; set; }

        [Required]
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        [Required]
        public int BaseCalculationId { get; set; }
        public virtual BaseCalculation BaseCalculation { get; set; }
    }
}

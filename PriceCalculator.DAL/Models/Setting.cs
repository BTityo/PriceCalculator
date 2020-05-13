using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceCalculator.DAL.Models
{
    [Table("Setting", Schema = "Setting")]
    public class Setting : BaseModel
    {
        [Required, DefaultValue(false)]
        public bool IsStartWithWindows { get; set; }

        [Required, DefaultValue("Felhasználó")]
        public string UserName { get; set; }

        [Required, DefaultValue("Windows")]
        public string Platform { get; set; }
    }
}

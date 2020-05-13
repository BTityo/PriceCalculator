using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceCalculator.DAL.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InsertDate { get; set; }

        public DateTime? LastChangeDate { get; set; }
    }
}

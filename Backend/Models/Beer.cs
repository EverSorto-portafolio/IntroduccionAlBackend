using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BeerId { get; set; }
        public string BeerName { get; set; }

        public int BrandId { get; set; }

        //Añadimos 
        [Column(TypeName ="decimal(18,2)")]
        public decimal Al { get; set; }
        // si tiene decimal debemos definir cuantos decimales


        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set;}
    }
}

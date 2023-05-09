using System.ComponentModel.DataAnnotations;
namespace NesrineDziri.Models
{
    public  class MakeUp
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]

        public string Nom { get; set; } = null!;
        [Required]

        public Marque Marque { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:0.0#}")]
        public decimal Rating { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Marque Link")]
        public string? MarqueUrl { get; set; }


        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster")]
        public string? ImageUrl { get; set; }

        public int Perfumery_StoreId { get; set; }
        public virtual Perfumery_Store? Perfumery_Store { get; set; } = null!;

    }
}

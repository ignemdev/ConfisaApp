using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConfisaApp.Models
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string RNC { get; set; }
        [Required]
        [StringLength(150,MinimumLength =1)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Telefono { get; set; }
        [StringLength(150, MinimumLength = 1)]
        public string Email { get; set; }
        public bool Activado { get; set; }
        [Display(Name ="Oficial")]
        public int? OficialId { get; set; }
        [ForeignKey("OficialId")]
        public Oficial Oficial { get; set; }

    }
}

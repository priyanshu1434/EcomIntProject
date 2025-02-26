using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomIntProject.Models
{
    internal class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdminId { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]

        public int Username { get; set; }

        [Required]

        public string? AdminName { get; set; }

        [Required]

        [RegularExpression("^(SuperAdmin|Seller)$", ErrorMessage = "Role must be SuperAdmin or Seller.")]
        public string? Role { get; set; }

    }
}

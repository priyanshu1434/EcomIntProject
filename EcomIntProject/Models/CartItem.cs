using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomIntProject.Models
{
    internal class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartItemId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}

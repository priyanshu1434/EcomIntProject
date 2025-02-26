using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomIntProject.Models
{
    internal class Order
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderId { get; set; }

        [Required]

        [ForeignKey("User")]

        public int UserId { get; set; }

        [Required]

        [ForeignKey("Product")]

        public int ProductId { get; set; }

        [Required]

        public decimal TotalPrice { get; set; }

        [Required]

        [MaxLength(250)]

        public string ShippingAddress { get; set; }

        [Required]

        [MaxLength(50)]

        public string OrderStatus { get; set; }

        [Required]

        [MaxLength(50)]

        public string PaymentStatus { get; set; }

        [Required]

        public DateTime OrderDate { get; set; }

        public virtual User User { get; set; }

        public virtual Product Product { get; set; }

    }
}

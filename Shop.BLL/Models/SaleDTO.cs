using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class SaleDTO
    {
        public int SaleId { get; set; }

        public int UserId { get; set; }

        public DateTime DateCreate { get; set; }
    }
}

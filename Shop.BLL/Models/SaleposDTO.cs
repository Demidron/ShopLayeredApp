using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Models
{
    public class SaleposDTO
    {
        public int SaleposId { get; set; }

        public int SaleId { get; set; }

        public int GoodId { get; set; }

        public int GoodAmount { get; set; }
    }
}

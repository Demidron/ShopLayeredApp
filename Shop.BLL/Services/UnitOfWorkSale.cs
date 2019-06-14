using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public class UnitOfWorkSale : IUnitOfWorkSale
    {
        private bool disposed = false;

        public UnitOfWorkSale(TransactionScope transact,
            IGenericService<GoodDTO> goodService,
            IGenericService<SaleDTO> saleService,
            IGenericService<SaleposDTO> saleposService)
        {
            this.transact = transact;
            this.goodService = goodService;
            this.saleService = saleService;
            this.saleposService = saleposService;
        }

        public TransactionScope transact
        {
            get;
        }

        public IGenericService<SaleDTO> saleService { get; }

        public IGenericService<SaleposDTO> saleposService { get; }

        public IGenericService<GoodDTO> goodService { get; }

        public void Save()
        {
            transact.Complete();
        }



        
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    transact.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

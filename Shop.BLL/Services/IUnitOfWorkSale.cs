using Shop.BLL.Models;
using System.Transactions;

namespace Shop.BLL.Services
{
    public interface IUnitOfWorkSale : IUnitOfWork
    {
        TransactionScope transact { get; }
        IGenericService<SaleDTO> saleService { get; }
        IGenericService<SaleposDTO> saleposService { get; }
        IGenericService<GoodDTO> goodService { get; }
    }
}

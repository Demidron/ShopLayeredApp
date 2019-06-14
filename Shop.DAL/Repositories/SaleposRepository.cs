using Shop.DAL.DbLayer;
using Step.Repository;
using System.Data.Entity;


namespace Shop.DAL.Repositories
{
    public class SaleposRepository : GenericRepository<Salepos>
    {
        public SaleposRepository(DbContext context) : base(context)
        {
        }
    }
}

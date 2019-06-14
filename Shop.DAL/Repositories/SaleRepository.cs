using Shop.DAL.DbLayer;
using Step.Repository;
using System.Data.Entity;


namespace Shop.DAL.Repositories
{
    public class SaleRepository : GenericRepository<Sale>
    {
        public SaleRepository(DbContext context) : base(context)
        {
        }
    }
}

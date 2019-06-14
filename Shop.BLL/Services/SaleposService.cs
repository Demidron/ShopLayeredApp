using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Shop.BLL.Models;
using Shop.DAL.DbLayer;
using Step.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class SaleposService : IGenericService<SaleposDTO>
    {
        IGenericRepository<Salepos> saleposRepository;
        private readonly IMapper _mapper;
        public SaleposService(IGenericRepository<Salepos> saleposRepository)
        {
            this.saleposRepository = saleposRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Salepos, SaleposDTO>();
                cfg.CreateMap<SaleposDTO, Salepos>();

            }).CreateMapper();
        }

        public SaleposDTO Add(SaleposDTO obj)
        {
            Salepos sale = _mapper.Map<Salepos>(obj);
            saleposRepository.AddOrUpdate(sale);
            saleposRepository.Save();
            return _mapper.Map<SaleposDTO>(sale);

        }
        public IEnumerable<SaleposDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleposDTO> FindBy(Expression<Func<SaleposDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public SaleposDTO Get(int id)
        {
            throw new NotImplementedException();
        }

       

        public SaleposDTO Update(SaleposDTO obj)
        {
            throw new NotImplementedException();
        }

        public SaleposDTO Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

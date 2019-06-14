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
    public class SaleService : IGenericService<SaleDTO>
    {
        IGenericRepository<Sale> saleRepository;
        private readonly IMapper _mapper;
        public SaleService(IGenericRepository<Sale> saleRepository)
        {
            this.saleRepository = saleRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Sale, SaleDTO>();
                cfg.CreateMap<SaleDTO, Sale>();

            }).CreateMapper();
        }

        public SaleDTO Add(SaleDTO obj)
        {
            Sale sale = _mapper.Map<Sale>(obj);
            saleRepository.AddOrUpdate(sale);
            saleRepository.Save();
            return _mapper.Map<SaleDTO>(sale);
        }

        public SaleDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleDTO> FindBy(Expression<Func<SaleDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public SaleDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public SaleDTO Update(SaleDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

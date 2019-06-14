using LinqKit;
using Shop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Shop.WebAPI.Models
{
    public class ViewModelFind
    {
        public string GoodName { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
    public class ViewModelFindExt
    {
        public ViewModelFind ModelFind { get; set; }
        public Expression<Func<GoodDTO, bool>> Predicate
        {
            get
            {
                var predicate = PredicateBuilder.New<GoodDTO>(true);

                if (!string.IsNullOrEmpty(ModelFind.GoodName))
                    predicate = predicate.And(g => g.GoodName.Contains(ModelFind.GoodName));
                if (ModelFind.PriceFrom != null)
                    predicate = predicate.And(g => g.Price >= ModelFind.PriceFrom);

                if (ModelFind.PriceTo != null)
                    predicate = predicate.And(g => g.Price <= ModelFind.PriceTo);


                return predicate;
            }
        }
    }
}
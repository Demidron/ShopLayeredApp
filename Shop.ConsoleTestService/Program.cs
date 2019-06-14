using Autofac;
using Shop.BLL.Models;
using Shop.BLL.Modules;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Transactions;


namespace Shop.ConsoleTestService
{
    class Program
    {
        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            return builder.Build();
        }
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var unitOf = container.Resolve<IUnitOfWorkSale>();

            List<Cart> carts = new List<Cart>()
            {
                new Cart{  GoodId = 2, GoodCount=1},
                new Cart{  GoodId = 4, GoodCount=2},
                new Cart{  GoodId = 14, GoodCount=2},
            };

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    SaleDTO sale = new SaleDTO
                    {
                        UserId = 1,
                        DateCreate = DateTime.Now
                    };
                    var s = unitOf.saleService.Add(sale);
                    foreach (var cart in carts)
                    {
                        SaleposDTO pos = new SaleposDTO
                        {
                            SaleId = s.SaleId,
                            GoodId = cart.GoodId,
                            GoodAmount = (int)cart.GoodCount
                        };
                        GoodDTO good = unitOf.goodService.Get(cart.GoodId);
                        good.GoodCount -= cart.GoodCount;
                        unitOf.goodService.Update(good);
                        unitOf.saleposService.Add(pos);
                    }
                    //itOf.Save();
                    scope.Complete();
                    Console.WriteLine("OK");
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.InnerException);
                }

            }


        }
    }
}

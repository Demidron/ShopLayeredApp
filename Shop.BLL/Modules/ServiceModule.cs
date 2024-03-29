﻿using Autofac;
using Shop.BLL.Models;
using Shop.BLL.Services;
using Shop.DAL.DbLayer;
using Shop.DAL.Repositories;
using Step.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Shop.BLL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Salepos
            builder.RegisterType(typeof(SaleposService))
                        .As(typeof(IGenericService<SaleposDTO>));
            builder.RegisterType(typeof(SaleposRepository))
                      .As(typeof(IGenericRepository<Salepos>));
            //Sale
            builder.RegisterType(typeof(SaleService))
                        .As(typeof(IGenericService<SaleDTO>));
            builder.RegisterType(typeof(SaleRepository))
                      .As(typeof(IGenericRepository<Sale>));
            //Category
            builder.RegisterType(typeof(CategoryService))
                        .As(typeof(IGenericService<CategoryDTO>));
            builder.RegisterType(typeof(CategoryRepository))
                      .As(typeof(IGenericRepository<Category>));

            //Manufacturer
            builder.RegisterType(typeof(ManufacturerService))
                         .As(typeof(IGenericService<ManufacturerDTO>));
            builder.RegisterType(typeof(ManufacturerRepository))
                      .As(typeof(IGenericRepository<Manufacturer>));
            //Good
            builder.RegisterType(typeof(GoodService))
                       .As(typeof(IGenericService<GoodDTO>));
            builder.RegisterType(typeof(GoodRepository))
                      .As(typeof(IGenericRepository<Good>));
            //Photo
            builder.RegisterType(typeof(PhotoService))
                         .As(typeof(IGenericService<PhotoDTO>));
            builder.RegisterType(typeof(PhotoRepository))
                      .As(typeof(IGenericRepository<Photo>));

            builder.RegisterType(typeof(ShopContext))
                     .As(typeof(DbContext)).InstancePerLifetimeScope();
            //UnitOfWorkSale: IUnitOfWorkSale
            builder.RegisterType(typeof(UnitOfWorkSale))
                     .As(typeof(IUnitOfWorkSale));
            builder.RegisterType(typeof(TransactionScope)).As(typeof(TransactionScope))
                    .WithParameter("scopeOption", TransactionScopeOption.RequiresNew)
                    .InstancePerLifetimeScope();
        }
    }
}

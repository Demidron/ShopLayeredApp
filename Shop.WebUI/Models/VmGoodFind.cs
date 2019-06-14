﻿using LinqKit;
using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Shop.WebUI.Models
{

    public class CategoryCheck
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ManufacturerCheck
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public bool IsCheck { get; set; }
    }
    public class VmGoodFind
    {
        IGenericService<CategoryDTO> categoryService;
        IGenericService<ManufacturerDTO> manufacturerService;
        public VmGoodFind() { }
        public VmGoodFind(IGenericService<CategoryDTO> categoryService,
                                    IGenericService<ManufacturerDTO> manufacturerService)
        {
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            CategorySelects = categoryService.GetAll()
                .Select(c => new CategoryCheck
                { CategoryId = c.CategoryId, CategoryName=c.CategoryName }).ToList();
            ManufacturerSelects = manufacturerService.GetAll()
                .Select(c => new ManufacturerCheck
                {  ManufacturerId = c.ManufacturerId,  ManufacturerName = c.ManufacturerName }).ToList();
        }

        public string GoodName { get; set; }
        public List<CategoryCheck> CategorySelects { get; set; }
        public List<ManufacturerCheck> ManufacturerSelects { get; set; }
        public Expression<Func<GoodDTO, bool>> Predicate
        {
            get
            {
                var predicate = PredicateBuilder.New<GoodDTO>(true);
                if (!string.IsNullOrEmpty(GoodName))
                    predicate = predicate.And(g => g.GoodName.Contains(GoodName));

                if(CategorySelects.Select(s=>s.IsCheck).Count()>0)
                {
                    var predCategory = PredicateBuilder.New<GoodDTO>(true);
                    foreach (var item in CategorySelects)
                    {
                        if(item.IsCheck)
                        {
                            predCategory = predCategory.Or(c => c.CategoryId == item.CategoryId);
                        }
                    }
                    predicate = predicate.And(predCategory);
                }
                if (ManufacturerSelects.Select(s => s.IsCheck).Count() > 0)
                {
                    var predManufacturer = PredicateBuilder.New<GoodDTO>(true);
                    foreach (var item in ManufacturerSelects)
                    {
                        if (item.IsCheck)
                        {
                            predManufacturer = predManufacturer.Or(c => c.ManufacturerId == item.ManufacturerId);
                        }
                    }
                    predicate = predicate.And(predManufacturer);
                }

                return predicate;
            }
        }
    }
}
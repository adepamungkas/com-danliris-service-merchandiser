﻿using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System.Linq.Dynamic.Core;
using Com.Moonlay.NetCore.Lib;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;

namespace Com.Danliris.Service.Merchandiser.Lib.Services
{
    public class CostCalculationGarment_MaterialService : BasicService<MerchandiserDbContext, CostCalculationGarment_Material>, IMap<CostCalculationGarment_Material, CostCalculationGarment_MaterialViewModel>, ICostCalculationGarment_Material
    {
        protected IIdentityService IdentityService;

        IEnumerable<CostCalculationGarment_Material> ICostCalculationGarment_Material.DbSet => throw new NotImplementedException();

        public CostCalculationGarment_MaterialService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public override Tuple<List<CostCalculationGarment_Material>, int, Dictionary<string, string>, List<string>> ReadModel(int Page = 1, int CostCalculationGarment_Material = 25, string Order = "{}", List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            IQueryable<CostCalculationGarment_Material> Query = this.DbContext.CostCalculationGarment_Materials;

            List<string> SearchAttributes = new List<string>()
                {
                    "Code"
                };
            Query = ConfigureSearch(Query, SearchAttributes, Keyword);

            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
                {
                    "Id", "Code"
                };
            Query = Query
                .Select(b => new CostCalculationGarment_Material
                {
                    Id = b.Id,
                    Code = b.Code
                });

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);
            Query = ConfigureOrder(Query, OrderDictionary);

            Pageable<CostCalculationGarment_Material> pageable = new Pageable<CostCalculationGarment_Material>(Query, Page - 1, CostCalculationGarment_Material);
            List<CostCalculationGarment_Material> Data = pageable.Data.ToList<CostCalculationGarment_Material>();
            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }

        public override async Task<int> CreateModel(CostCalculationGarment_Material Model)
        {
            int Created = 0;

            Created = await this.CreateAsync(Model);

            return Created;
        }

        public override void OnCreating(CostCalculationGarment_Material model)
        {
            do
            {
                model.Code = Code.Generate();
            }
            while (this.DbSet.Any(d => d.Code.Equals(model.Code)));

            base.OnCreating(model);
        }

        public CostCalculationGarment_MaterialViewModel MapToViewModel(CostCalculationGarment_Material model)
        {
            throw new NotImplementedException();
        }

        public CostCalculationGarment_Material MapToModel(CostCalculationGarment_MaterialViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        Task ICostCalculationGarment_Material.UpdateModel(int id, CostCalculationGarment_Material costCalculationGarment_Material)
        {
            throw new NotImplementedException();
        }

        public ReadResponse<CostCalculationGarment_Material> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<CostCalculationGarment_Material> ReadByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(CostCalculationGarment_Material model)
        {
            throw new NotImplementedException();
        }
    }
}

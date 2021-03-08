using System;
using Delsoft.Course.CQRS.Domain.Services;
using Delsoft.Course.CQRS.Model.Aggregates;

namespace Delsoft.Course.CQRS.Data
{
    public class WineRepository : IWineRepository
    {
        private readonly ApiContext _apiContext;

        public WineRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public void Create(Wine wine) => _apiContext.Update(new Delsoft.Course.CQRS.Model.Data.Wine()
        {
            Appellation = wine.Appellation,
            Millesime = wine.Millesime,
            Name =  wine.Name,
        });
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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

        public IReadOnlyCollection<Wine> GetBy(string appellation, int millesime)
        {
            IQueryable<Model.Data.Wine> query = _apiContext.Wines;
            if (!string.IsNullOrWhiteSpace(appellation))
            {
                query = query.Where(wine => wine.Appellation == appellation);
            }
            else if (millesime != default)
            {
                query = query.Where(wine => wine.Millesime == millesime);
            }

            return query.ToList()
                .Select(s => Wine.Create(s.Name, s.Millesime, s.Appellation))
                .ToList();
        }
    }
}
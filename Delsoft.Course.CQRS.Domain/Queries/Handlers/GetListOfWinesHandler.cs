using System.Collections.Generic;
using Delsoft.Course.CQRS.Domain.Services;
using Delsoft.Course.CQRS.Model.Aggregates;
using Delsoft.Course.CQRS.Model.Queries;

namespace Delsoft.Course.CQRS.Domain.Queries.Handlers
{
    public class GetListOfWinesHandler : IQueryHandler<GetListOfWinesQuery, IReadOnlyCollection<Wine>>
    {
        private readonly IWineRepository _wineRepository;

        public GetListOfWinesHandler(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public IReadOnlyCollection<Wine> Handle(GetListOfWinesQuery query)
        {
            return _wineRepository.GetBy(query.Appellation, query.Millesime);
        }
    }
}
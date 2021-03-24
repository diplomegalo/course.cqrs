using System.Collections.Generic;
using Delsoft.Course.CQRS.Dtos.Queries;
using Delsoft.Course.CQRS.Model.Aggregates;

namespace Delsoft.Course.CQRS.Model.Queries
{
    public class GetListOfWinesQuery : IQuery<IReadOnlyCollection<Wine>>
    {
        public GetListOfWinesQuery(int millesime, string appellation)
        {
            this.Millesime = millesime;
            this.Appellation = appellation;
        }

        public int Millesime { get; }
        public string Appellation { get; }
    }
}
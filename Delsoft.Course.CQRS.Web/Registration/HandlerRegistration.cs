using System;
using System.Collections.Generic;
using Delsoft.Course.CQRS.Domain.Commands;
using Delsoft.Course.CQRS.Domain.Commands.Decorators;
using Delsoft.Course.CQRS.Domain.Commands.Handlers;
using Delsoft.Course.CQRS.Domain.Queries;
using Delsoft.Course.CQRS.Domain.Queries.Handlers;
using Delsoft.Course.CQRS.Domain.Services;
using Delsoft.Course.CQRS.Model.Aggregates;
using Delsoft.Course.CQRS.Model.Commands;
using Delsoft.Course.CQRS.Model.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Delsoft.Course.CQRS.Web.Registration
{
    public static class HandlerRegistration
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandBus, CommandBus>();
            services.AddTransient<ICommandHandler<RegisterWine>>(provider
                => new Logging<RegisterWine>(new RegisterWineHandler(provider.GetService<IWineRepository>())));

            services.AddTransient<IQueryBus, QueryBus>();
            services.AddTransient<IQueryHandler<GetListOfWinesQuery, IReadOnlyCollection<Wine>>, GetListOfWinesHandler>();
        }
    }
}
﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Data.EntityFramework.Repositories;

namespace Web.Api.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerLifetimeScope();
        }
    }

}

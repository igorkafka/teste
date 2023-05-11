using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TesteEmpresa.Data.Context;
using TesteEmpresa.Data.Repository;
using TesteEmpresa.Interfaces;

namespace TesteEmpresa.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // Lifestyle.Singleton
            // Uma única instância por aplicação

            // Lifestyle.Transient
            // Cria uma nova instância para cada injeção

            //Lifestyle.Scoped
            // Uma única instância por request

            container.Register<DbTesteContext>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IVendaRepository, VendaRepositroy>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);

        }
    }
}
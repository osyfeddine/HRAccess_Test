using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

using Unity;
using AppWeb.DI;
using AppWeb.DI.Unity.ContainerExtensions;

internal class CompositionRoot
{
    public static IUnityContainer Compose()
    {
        var container = new UnityContainer();

        container.AddNewExtension<RepositoryContainerExtension>();
        container.AddNewExtension<ServiceContainerExtension>();
        container.AddNewExtension<DbContextContainerExtension>();

        var provider = new UnityFilterAttributeFilterProvider(container);
        FilterProviders.Providers.Add(provider);
        return container;
        


      
    }
}

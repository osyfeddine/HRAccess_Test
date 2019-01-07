using System;
using System.Web.Mvc;


using Unity.Mvc5;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
//using Microsoft.Practices.Unity.Mvc;
using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DIConfig), "Register")]



public class DIConfig
{
    public static void Register()
    {

       
        var container = CompositionRoot.Compose();

#if DependencyResolver
// ************************************************************************************** //
//  Dependency Resolver
//
//  You may use this option if you are using MVC 3 or higher and you have other code
//  that references DependencyResolver.Current.GetService() or DependencyResolver.Current.GetServices()
//
// ************************************************************************************** //

// Reconfigure MVC to use Service Location
        var dependencyResolver = new InjectableDependencyResolver(container, DependencyResolver.Current);
        DependencyResolver.SetResolver(dependencyResolver);
#else
// ************************************************************************************** //
//  Controller Factory
//
//  It is recommended to use Controller Factory unless you are getting errors due to a conflict.
//
// ************************************************************************************** //

// Reconfigure MVC to use DI

       
        DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

        DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));

       

        
#endif

        

    }
}


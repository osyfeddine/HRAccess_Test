using Business.Abstract;
using Entities;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Unity;
using Unity.Extension;
using Unity.RegistrationByConvention;

namespace AppWeb.DI.Unity.ContainerExtensions
{
   public class ServiceContainerExtension : UnityContainerExtension
    {

       
        protected override void Initialize()
        {
            Container.RegisterTypes(
            AllClasses.FromLoadedAssemblies().Where(t => t.Namespace == "Business.Concrete"),
            WithMappings.FromMatchingInterface,
            WithName.Default,
            WithLifetime.None);

           
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

using Microsoft.Practices.Unity;
using System.ComponentModel;
using Unity.Extension;
using Unity.RegistrationByConvention;

namespace AppWeb.DI.Unity.ContainerExtensions
{
    public class RepositoryContainerExtension : UnityContainerExtension
    {
      
        protected override void Initialize()
        {
           
                  Container.RegisterTypes(
                  AllClasses.FromLoadedAssemblies().Where(t => t.Namespace == "DAO.Concrete"),
                  WithMappings.FromMatchingInterface,
                  WithName.Default,
                  WithLifetime.None);

        }

    }
}
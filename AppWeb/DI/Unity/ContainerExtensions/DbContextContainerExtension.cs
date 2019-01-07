using DAO.Common;
using Entities.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Extension;

namespace AppWeb.DI.Unity.ContainerExtensions
{
        
    public class DbContextContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            
            Container.AddNewExtension<RepositoryContainerExtension>();
            Container.RegisterType<DbContext, SyfoContext>(new  PerRequestLifetimeManager());
            Container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());

            
            
        }

    }
}
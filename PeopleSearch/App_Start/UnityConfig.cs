using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PeopleSearch.Services.Implementations;
using PeopleSearch.Services.Interfaces;
using Unity.Mvc5;

namespace PeopleSearch
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IDataContext, DataContext>();
            container.RegisterType<IContactService, ContactService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
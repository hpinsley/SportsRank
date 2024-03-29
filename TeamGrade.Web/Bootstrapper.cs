using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ScoreParser;
using Unity.Mvc3;

namespace TeamGrade.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();            

            container.RegisterType<ITeamManager, TeamManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IGameManager, GameManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IResultsParser, ResultsParser>(new ContainerControlledLifetimeManager());

            return container;
        }
    }
}
using ApplicationLayer.Services;
using Domain.Events;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Loaders;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Bootstrap
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameBootstrapper _bootstrapper;
    
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(new SceneLoader()).As<SceneLoader>();
            builder.RegisterInstance(BuildingConfigFactory.Create())
                .As<BuildingConfig>();
        
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<BuildingPlacedEvent>(options);
            builder.RegisterMessageBroker<BuildingRemovedEvent>(options); 
            
            builder.Register<GridService>(Lifetime.Singleton); 
            builder.Register<EconomyService>(Lifetime.Singleton);
            
            builder.RegisterInstance(_bootstrapper).As<IGameBootstrapper>();
        }

        protected void Start()
        {
            Container.Inject(_bootstrapper);
        }
    }
}

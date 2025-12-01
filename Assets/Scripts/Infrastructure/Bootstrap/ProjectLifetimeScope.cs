using Domain.Events;
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
            builder.RegisterInstance(_bootstrapper).As<IGameBootstrapper>();
            builder.RegisterInstance(new SceneLoader()).As<SceneLoader>();
        
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<BuildingPlacedEvent>(options);
            builder.RegisterMessageBroker<BuildingRemovedEvent>(options); 
        }

        protected void Start()
        {
            Container.Inject(_bootstrapper);
        }
    }
}

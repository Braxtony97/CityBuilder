using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ProjectLifetimeScope : LifetimeScope
{
    [SerializeField] private GameBootstrapper _bootstrapper;
    [SerializeField] private CoroutineRunner _coroutineRunner;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_coroutineRunner).As<ICoroutineRunner>();
        builder.RegisterInstance(_bootstrapper).As<IGameBootstrapper>();
        builder.Register<SceneLoader>(resolver => 
            new SceneLoader(resolver.Resolve<ICoroutineRunner>()), Lifetime.Singleton);
        
        var options = builder.RegisterMessagePipe();
        builder.RegisterMessageBroker<BuildingPlacedEvent>(options);
        builder.RegisterMessageBroker<BuildingRemovedEvent>(options); 
    }

    protected void Start()
    {
        Container.Inject(_bootstrapper);
    }
}

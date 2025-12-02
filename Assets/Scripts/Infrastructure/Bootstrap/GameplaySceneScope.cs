using ApplicationLayer.UseCases;
using Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Bootstrap
{
    public class GameplaySceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PlaceBuildingUseCase>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<GridView>();
        }
    }
}
using Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Bootstrap
{
    public class PlaymodeLifetimeScope : LifetimeScope
    {
        [SerializeField] private GridView _gridView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GridView>();
        }
        
        protected void Start()
        {
            if (_gridView != null)
            {
                Container.Inject(_gridView);
                Debug.Log("GridView injected!");
            }
        }
    }
}
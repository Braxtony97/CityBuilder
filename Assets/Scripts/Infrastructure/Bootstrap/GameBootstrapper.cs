using Cysharp.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Loaders;
using UnityEngine;
using VContainer;

namespace Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour, IGameBootstrapper
    {
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(SceneLoader sceneLoader) => 
            _sceneLoader = sceneLoader;

        private async void Start()
        {
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(this);

            try
            {
                await LoadSceneAsync();
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error while loading scene: {e}");
            }
        }

        private async UniTask LoadSceneAsync()
        {
            await _sceneLoader.LoadAsync("Playmode");
        }
    }
}
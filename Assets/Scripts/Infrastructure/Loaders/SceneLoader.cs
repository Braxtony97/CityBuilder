using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Infrastructure.Loaders
{
    public class SceneLoader
    {
        public async UniTask LoadAsync(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                return;
            }

            var asyncOp = SceneManager.LoadSceneAsync(sceneName);
            
            await asyncOp.ToUniTask();

            onLoaded?.Invoke();
        }
    }
}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly ICoroutineRunner _runner;

    public SceneLoader(ICoroutineRunner runner) => 
        _runner = runner;

    public void Load(string sceneName, Action onLoaded = null) => 
        _runner.StartCoroutine(LoadSceneRoutine(sceneName, onLoaded));

    private IEnumerator LoadSceneRoutine(string sceneName, Action onLoaded)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            onLoaded?.Invoke();
            yield break;
        }

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOp.isDone)
        {
            yield return null;
        }

        onLoaded?.Invoke();
    }    
}
using UnityEngine;
using VContainer;

public class GameBootstrapper : MonoBehaviour, IGameBootstrapper
{
    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(SceneLoader sceneLoader) => 
        _sceneLoader = sceneLoader;

    private void Start()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this);

        LoadScene();
    }

    private void LoadScene() => 
        _sceneLoader.Load("Playmode");
}
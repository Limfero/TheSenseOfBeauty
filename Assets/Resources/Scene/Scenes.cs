using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Game))]
public class Scenes : MonoBehaviour
{
    [SerializeField] private EndWindowView _endWindow;
    [SerializeField] private int _idNextScene;

    private Game _game;

    private void Awake()
    {
        _game = GetComponent<Game>();
    }

    private void OnEnable()
    {
        _game.Ended += End;
        _endWindow.NextButtonPresed += LoadNextScene;
        _endWindow.RestartButtonPresed += RestartScene;
    }

    private void OnDisable()
    {
        _game.Ended -= End;
        _endWindow.NextButtonPresed -= LoadNextScene;
        _endWindow.RestartButtonPresed -= RestartScene;
    }

    private void End(int finalId)
    {
        Time.timeScale = 0;
        _endWindow.Enable(finalId);
    }

    private void LoadNextScene() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_idNextScene);
    }

    private void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

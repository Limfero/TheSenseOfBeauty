using Presenters.Games;
using UnityEngine;
using UnityEngine.SceneManagement;
using View;

namespace SceneSystem
{
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
            _endWindow.Enable(finalId);
        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(_idNextScene);
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

namespace View
{
    [RequireComponent(typeof(Animator))]
    public class EndWindowView : MonoBehaviour
    {
        private const string Show = nameof(Show);

        [SerializeField] private PlayerResults _results;
        [SerializeField] private Button _restart;
        [SerializeField] private Button _next;
        [SerializeField] private List<StarView> _stars;

        private int _sceneId;

        public event Action Enabled;
        public event Action RestartButtonPresed;
        public event Action NextButtonPresed;

        private void Awake()
        {
            _sceneId = SceneManager.GetActiveScene().buildIndex;
        }

        private void OnEnable()
        {
            _restart.onClick.AddListener(Restart);
            _next.onClick.AddListener(Next);
        }

        private void OnDisable()
        {
            _restart.onClick.RemoveListener(Restart);
            _next.onClick.RemoveListener(Next);
        }

        public void Enable(int finalId)
        {
            gameObject.SetActive(true);
            Enabled?.Invoke();

            for (int i = 0; i < _stars.Count; i++)
                if (_results.CheckFinal(i + 1, _sceneId))
                    _stars[i].ChangeStar();

            if (_results.CheckFinal(finalId, _sceneId) == false)
                _stars[finalId - 1].OnStar();

            _results.Save(finalId, _sceneId);
        }

        private void Restart() => RestartButtonPresed?.Invoke();

        private void Next() => NextButtonPresed?.Invoke();
    }
}
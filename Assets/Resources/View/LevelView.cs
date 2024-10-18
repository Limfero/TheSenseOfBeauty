using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private PlayerResults _results;
    [SerializeField] private int _idSceneLevel;
    [SerializeField] private List<StarView> _stars;

    private void Start()
    {
        for (int i = 0; i < _stars.Count; i++)
            if (_results.CheckFinal(i + 1, _idSceneLevel))
                _stars[i].On();
    }
}

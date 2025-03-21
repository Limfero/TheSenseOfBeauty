using Models;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Presenters.Games
{
    public abstract class Game : MonoBehaviour
    {
        [SerializeField] protected List<Final> Finals;

        public abstract event Action<int> Ended;

        public IReadOnlyList<Final> AllFinals => Finals;
    }
}
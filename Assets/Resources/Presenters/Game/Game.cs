using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Game : MonoBehaviour
{
    [SerializeField] protected List<Final> Finals;

    public abstract event Action<int> Ended;
}

using Presenters;
using UnityEngine;

namespace View.SlotModules
{
    [RequireComponent(typeof(SlotPresenter))]
    public abstract class SlotModule : MonoBehaviour
    {
        protected SlotPresenter SlotPresenter;

        private void Awake()
        {
            SlotPresenter = GetComponent<SlotPresenter>();
        }
    }
}
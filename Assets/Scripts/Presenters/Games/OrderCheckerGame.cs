using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using View;

namespace Presenters.Games
{
    public class OrderCheckerGame : Game
    {
        [SerializeField] private OrderChecker _checker;

        public override event Action<int> Ended;

        private void OnEnable()
        {
            _checker.Cheked += OnCheck;
        }

        private void OnDisable()
        {
            _checker.Cheked -= OnCheck;
        }

        private void OnCheck(List<int> itemsId)
        {
            foreach (Final final in Finals)
            {
                if (CheckFinalWithOrder(final, itemsId) == true)
                {
                    Ended?.Invoke(final.FinalId);
                    return;
                }
            }
        }

        private bool CheckFinalWithOrder(Final final, List<int> itemsId)
        {
            foreach (ItemsInSlot itemsInSlot in final.ItemsInSlots)
                if (itemsInSlot.Items.SequenceEqual(itemsId) == false)
                    return false;

            return true;
        }
    }
}
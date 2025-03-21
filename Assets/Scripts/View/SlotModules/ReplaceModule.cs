using Presenters;
using System.Collections.Generic;

namespace View.SlotModules
{
    public class ReplaceModule : SlotModule
    {
        private void OnEnable()
        {
            SlotPresenter.Added += Replace;
        }

        private void OnDisable()
        {
            SlotPresenter.Added -= Replace;
        }

        private void Replace(ItemPresenter presenter)
        {
            List<ItemPresenter> items = new ();

            foreach (var item in SlotPresenter.Items)
                if (item != presenter)
                    items.Add(item);

            foreach (var item in items)
            {
                item.Disable();
                item.SetPosition(presenter.Position);
            }

            presenter.SetPosition(transform.position);

            items = new ();
        }
    }
}
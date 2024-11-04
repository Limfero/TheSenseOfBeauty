using UnityEngine;

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
        foreach (var item in SlotPresenter.Items)
            if (item != presenter)
                item.SetPosition(presenter.Position);

        presenter.SetPosition(transform.position);
    }
}

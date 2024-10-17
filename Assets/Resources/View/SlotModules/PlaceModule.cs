public class PlaceModule : SlotModule
{
    private void OnEnable()
    {
        SlotPresenter.Added += Place;
    }

    private void OnDisable()
    {
        SlotPresenter.Added -= Place;
    }

    private void Place(ItemPresenter presenter)
    {
        if(SlotPresenter.Items.Count - 1 == 0)
            presenter.SetPosition(transform.position);
    }
}

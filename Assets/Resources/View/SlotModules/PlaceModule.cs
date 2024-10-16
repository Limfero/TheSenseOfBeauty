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
        presenter.SetPosition(transform.position);
    }
}

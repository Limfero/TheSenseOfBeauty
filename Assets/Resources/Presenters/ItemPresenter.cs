using UnityEngine;

[RequireComponent (typeof(ItemView))]
public class ItemPresenter : MonoBehaviour
{
    [SerializeField] private int _id;

    private ItemView _view;
    private Vector3 _currentPosition;

    public int Id => _id;
    public Vector3 Position => _currentPosition;

    private void Awake()
    {
        _view = GetComponent<ItemView>();
    }

    public void SetPosition(Vector3 position)
    {
        _view.SetPosition(position);
        _currentPosition = position;
    }      
}

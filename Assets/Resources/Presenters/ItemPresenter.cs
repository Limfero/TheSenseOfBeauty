using UnityEngine;

public class ItemPresenter : MonoBehaviour
{
    [SerializeField] private ItemTypes _type;

    public ItemTypes Type => _type;

    public bool IsCorrectType(ItemTypes type) => _type == type;
}

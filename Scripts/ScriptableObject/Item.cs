using UnityEngine;

[CreateAssetMenu(menuName ="Item")]

public class Item : ScriptableObject
{
    public string strObjectName;

    public Sprite sprite;

    public int nQuantity;

    public bool bStackable;

    public enum eITEM_TYPE
    {
        NONE,
        COIN,
        HEALTH,
        _MAX_
    }

    public eITEM_TYPE ITEM_TYPE;
}

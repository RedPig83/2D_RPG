using UnityEngine;

public class Player : Character
{
    public HealthBar healthBarPrefab;
    private HealthBar healthBar;

    public Inventory inventoryPrefab;
    private Inventory inventory;

    private void Start()
    {
        inventory = Instantiate(inventoryPrefab);

        hp.fValue = fStartHp;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                bool bShouldDisappear = false;

                print("Hit: " + hitObject.strObjectName);

                switch (hitObject.ITEM_TYPE)
                {
                    case Item.eITEM_TYPE.COIN:
                        bShouldDisappear = inventory.AddItem(hitObject);                        
                        break;
                    case Item.eITEM_TYPE.HEALTH:
                        bShouldDisappear = AdjustHitPoints(hitObject.nQuantity);
                        break;
                    default:
                        break;
                }

                if (bShouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    public bool AdjustHitPoints(int nAmount)
    {
        if (hp.fValue < fMaxHp)
        {
            hp.fValue = hp.fValue + nAmount;

            print("Adjusted hitpoints by: " + nAmount + ". New value: " + hp.fValue);

            return true;
        }

        return false;
    }
}

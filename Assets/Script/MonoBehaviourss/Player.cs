using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public HealthPoint healthPoints;


    public HealthBar healthBarPrefab;
    HealthBar healthBar;

    public Inventory inventoryPrefab;
    Inventory inventory;


    private void OnEnable()
    {
        ResetCharacter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {

                bool shouldDisappear = false;

                /*
                print("Hit: "+ hitObject.objectName);
                collision.gameObject.SetActive(false);
                */

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:

                        shouldDisappear = inventory.AddItem(hitObject);
                        break;

                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHealthPoint(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }

            
        }
    }

    public bool AdjustHealthPoint(int amount)
    {
        
        if (healthPoints.value < maxHealthPoints)
        {
            healthPoints.value = healthPoints.value + amount;

            print("Adjusted HP by: "+amount + ". New value: "+healthPoints.value);

            return true;
        }
        return false;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            healthPoints.value = healthPoints.value - damage;

            if(healthPoints.value <= float.Epsilon)
            {
                KillCharacter();
                break;
            }

            if(interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public override void KillCharacter()
    {
        base.KillCharacter();

        Destroy(healthBar.gameObject);
        Destroy(inventory.gameObject);
    }

    public override void ResetCharacter()
    {
        inventory = Instantiate(inventoryPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;

        healthPoints.value = startingHealthPoints;
    }
}

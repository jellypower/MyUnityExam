using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject slotPrefab;
    public const int numSlots = 5;
    Image[] itemImages = new Image[numSlots];
    Item[] Items = new Item[numSlots];
    GameObject[] slots = new GameObject[numSlots];

    void Start()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateSlots()
    {
        if (slotPrefab != null)
        {
            for (int i = 0; i < numSlots; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab);
                newSlot.name = "ItemSlot_" + i;

                newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform, false);
                

                slots[i] = newSlot;

                itemImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < Items.Length;i++)
        {
            if(Items[i]!= null && Items[i].itemType == itemToAdd.itemType && itemToAdd.stackable == true)
            {
                Items[i].quantity = Items[i].quantity + 1;

                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                Text quantityText = slotScript.qtyText;

                quantityText.enabled = true;
                quantityText.text = Items[i].quantity.ToString();

                return true;
            }

            if(Items[i] == null)
            {
                Items[i] = Instantiate(itemToAdd);
                Items[i].quantity = 1;

                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return true;
            }
        }
        return false;
    }
}
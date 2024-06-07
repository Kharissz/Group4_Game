using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public EventHandler OnItemListChanged;
    public List<Item> itemList;

    public Inventory() 
    {
        itemList = new List<Item>();

        Debug.Log(itemList.Count);
        // Item test = itemList[3];
        // Debug.Log(test);
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable())
        {
            bool ItemAlreadyInInventory = false;
            foreach(Item inventoryItem in itemList)
            {
                if(inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount+=item.amount;
                    ItemAlreadyInInventory = true;
                }
            }

            if(!ItemAlreadyInInventory)
            {itemList.Add(item);}
        } 
        else
        {itemList.Add(item);}

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
    
}

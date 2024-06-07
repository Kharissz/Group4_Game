using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Item
{
    public enum ItemType{
        Lentera,
        Keris,
        Minyak,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        // Debug.Log(itemType);
        
        switch(itemType){
            default:
            case ItemType.Lentera:  return ItemAssets.Instance.LenteraSprite;
            case ItemType.Keris:    return ItemAssets.Instance.KerisSprite;
            case ItemType.Minyak:    return ItemAssets.Instance.MinyakSprite;
        }
    }

    public Color GetColor()
    {
        switch(itemType)
        {
            default:
            case ItemType.Lentera: return new Color(1,0,0);
            case ItemType.Keris: return new Color(0,1,0);
            case ItemType.Minyak: return new Color(0,0,1);
        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Minyak:
                return true;
            case ItemType.Lentera:
            case ItemType.Keris:
                return false;

        }
    }

}

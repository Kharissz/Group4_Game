using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering.Universal;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    private Light2D light2d;
    private TextMeshPro textMeshPro;

 
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        
        // if(itemWorld!=null) Debug.Log("itemWorld ada");

        itemWorld.SetItem(item);

        // Debug.Log(itemWorld);
        return itemWorld;

    }

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        light2d = GetComponent<Light2D>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
        // Debug.Log(textMeshPro.transform);

    }
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        light2d.color = item.GetColor();

        if(item.amount > 1)
        {textMeshPro.SetText(item.amount.ToString());}
        else
        {textMeshPro.SetText("");}
    }
    
    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

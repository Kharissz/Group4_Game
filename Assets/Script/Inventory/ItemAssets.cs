using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance{get; private set;}

    private void Awake()
    {
        Instance = this;
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Transform pfItemWorld;

    public Sprite LenteraSprite;
    public Sprite KerisSprite;
    public Sprite MinyakSprite;

}

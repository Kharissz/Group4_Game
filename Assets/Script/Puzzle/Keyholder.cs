using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyholder : MonoBehaviour
{
    public static Keyholder Instance{get; private set;}

    private HashSet<string> CollectedKey;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CollectedKey = new HashSet<string>();
            LoadCollectedKey();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectKey(string keyId)
    {
        if(!CollectedKey.Contains(keyId))
        {
            CollectedKey.Add(keyId);
            SaveCollectedKey();
        }
    }

    public void SaveCollectedKey()
    {
        PlayerPrefs.SetString("CollectedKey", string.Join(",", CollectedKey));
        PlayerPrefs.Save();
    }

    public bool IsKeyCollected(string keyId)
    {
        return CollectedKey.Contains(keyId);
    }

    public void LoadCollectedKey()
    {
        if(PlayerPrefs.HasKey("CollectedKey"))
        {
            string collectedKeyString = PlayerPrefs.GetString("CollectedKey");
            CollectedKey = new HashSet<string>(collectedKeyString.Split(','));
        }
        else
        {
            Debug.Log("GK ada Key");
        }
    }

    public void RestartCollectedKey()
    {
        CollectedKey.Clear();
        PlayerPrefs.DeleteKey("CollectedKey");
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
//using UnityEngine.AddressableAssets;

public class DataHandler : MonoBehaviour
{
    //TODO [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items;
    [SerializeField] private String label;

    private GameObject spawnableObject;
    private int current_id = 0;

    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        LoadItems();

        CreateButtons();
    }

    void LoadItems()
    {
        var itemsRes = Resources.LoadAll("Items", typeof(Item));
        foreach (var item in itemsRes)
        {
            items.Add(item as Item);
        }
    }

    void CreateButtons()
    {
        foreach (Item item in items)
        {
            //TODO ButtonManager newButton = Instantiate(buttonPrefab, buttonContainer.transform);
            //newButton.ItemID = current_id;
            //newButton.ButtonTexture = item.itemIcon;
            current_id++;
        }

       //TODO  buttonContainer.GetComponent<UIContentFitter>().ManualResize();
    }

    public void SetSpawnableObject(int id)
    {
        spawnableObject = items[id].itemPrefab;
    }
    public void SetSpawnableObject(AssetBundle bundle)
    {
        string rootAssetPath = bundle.GetAllAssetNames()[0];
        spawnableObject = bundle.LoadAsset(rootAssetPath) as GameObject;
    }

    public GameObject GetSpawnableObject()
    {
        return spawnableObject;
    }
}

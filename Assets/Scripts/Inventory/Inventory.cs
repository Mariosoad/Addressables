using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.XR.ARFoundation.Samples.Inventory;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;    
    [SerializeField] List<GameObject> models;
    bool panelActive;
    [SerializeField] GameObject inventoryPanel;

    public string avaibleModels;
    
    private void Awake()
    {
        panelActive = false;
    }

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        EventsManager.instance.ONModelsSetteds += SetModels;
    }

    private void SetModels(string obj)
    {
        avaibleModels = obj;
    }

    public void SetActiveUIInventory()
    {
        panelActive = !panelActive;
        inventoryPanel.SetActive(panelActive);
    }

    public AssetReference GetModelById(int id)
    {
        return AddressableInventory.instance.GetAddressableModel();
    }

}

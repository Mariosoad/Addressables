using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemModel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string id;
    [SerializeField] GameObject inventoryPanel;
    private void Awake()
    {
        string goName = gameObject.name;

        int fStr = goName.IndexOf("(");
        int sStr = goName.IndexOf(")");
        string number = goName.ToCharArray()[fStr + 1].ToString();
        if (goName.ToCharArray()[fStr + 2].ToString() != ")")
            number += goName.ToCharArray()[fStr + 2].ToString();
        id = number;
        text.text = id;
        
        
    }

    private void Start()
    {
        // ShouldIDie(Inventory.instance.avaibleModels);
    }

    private void ShouldIDie(string avaiblesModels)
    {
        var models = avaiblesModels.ToCharArray();
        bool beAlive = false;
        foreach (char model in models)
        {
            if (model.ToString() == id)
                beAlive = true;

        }

        if (!beAlive)
        {
            Destroy(gameObject);
        }
        
    }


    public void OnButtonClicked()
    {
        // EventsManager.instance.OnModelSelected(int.Parse(id));
        inventoryPanel.SetActive(false);
    }

}

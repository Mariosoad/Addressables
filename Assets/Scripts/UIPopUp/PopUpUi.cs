using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUi : MonoBehaviour
{

    [SerializeField] Button option1Button, option2Button, option3Button;
    [SerializeField] TextMeshPro textDesc;

    public PopUpUi SetButtonsState(bool state)
    {
        option1Button.gameObject.SetActive(state);
        option1Button.gameObject.SetActive(state);
        option1Button.gameObject.SetActive(state);
        return this;
    }

    public PopUpUi SetOption1Btn(Action action)
    {
        option1Button.onClick.AddListener(() => YourFunction());
        return this;
    }

    public void YourFunction() { }

    public PopUpUi SetText(string text)
    {
        textDesc.text = text;
        return this;
    }

}

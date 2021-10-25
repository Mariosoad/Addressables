using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
    Animator anim;
    bool turned;
    Button button;

    void Start()
    {
        EventsManager.instance.onChangeState += SetInteractableState;
        button = GetComponent<Button>();
    }

    private void SetInteractableState(EStates state)
    {
        if (state == EStates.Idle)
            button.interactable = true;
        else
            button.interactable = false;
    }

    public void SetAnim()
    {
        turned = !turned;
    }

}

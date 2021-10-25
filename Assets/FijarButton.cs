using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FijarButton : MonoBehaviour
{
    [SerializeField] Button button;

    private void Start()
    {
        EventsManager.instance.onChangeState += ChangeButtonState;
    }

    private void ChangeButtonState(EStates state)
    {
        if (state == EStates.RotatingAndScalingModel)
            button.interactable = true;
        else
            button.interactable = false;
    }

    public void Fijar()
    {
        EventsManager.instance.OnchangeState(EStates.Idle);
    }



}

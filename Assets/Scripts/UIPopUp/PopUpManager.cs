using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager instance;
    [SerializeField] GameObject alertPopUp;
    [SerializeField] Text popUpText;
    [SerializeField] float timeToUnablePopUp;

    EStates currentState;

    bool popUpActive;
    float timer;

    private void Awake()
    {
        Singleton();
    }

    private void Start()
    {
        EventsManager.instance.onPopUpCalled += SetPopUp;
        EventsManager.instance.onChangeState += SetState;
    }

    private void SetState(EStates state)
    {
        currentState = state;
    }

    private void SetPopUp(string message)
    {
        if (currentState == EStates.RotatingAndScalingModel)
            return;

        alertPopUp.SetActive(true);
        popUpActive = true;
        timer = timeToUnablePopUp;
        popUpText.text = message;

        EventsManager.instance.OnchangeState(EStates.Idle);
    }

    private void Update()
    {
        if (popUpActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                popUpActive = false;
                alertPopUp.SetActive(false);
                EventsManager.instance.OnchangeState(EStates.Idle);
            }
        }
    }

    private void Singleton()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }



}

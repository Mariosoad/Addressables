using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public EStates currentState;

    public static FSM instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        EventsManager.instance.OnchangeState(EStates.Idle);
    }

    public void SetModelSelectedState()
    {
        EventsManager.instance.OnchangeState(EStates.PlacingModel);
    }

}

public enum EStates
{
    Idle,
    PlacingModel,
    RotatingAndScalingModel
}
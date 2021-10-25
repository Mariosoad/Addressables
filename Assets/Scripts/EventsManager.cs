using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    public event Action<GameObject> onSpawnedObject;
    public void OnSpawnObject(GameObject go)
    {
        onSpawnedObject?.Invoke(go);
    }

    public event Action OnCollisionWithSpawnableObject;
    public void OnCollisionWithSpawnedObject()
    {
        OnCollisionWithSpawnableObject?.Invoke();
    }

    public event Action<float, GameObject> OnGetDistanceToSpawnedObject;
    public void GetDistanceToSpawnedObject(float distance, GameObject go)
    {
        OnGetDistanceToSpawnedObject?.Invoke(distance, go);
    }


    public event Action<int> onModelSelected;
    public void OnModelSelected(int id)
    {
        onModelSelected.Invoke(id);
    }

    public event Action<string> onPopUpCalled;
    public void OnShowPopUp(string message)
    {
        onPopUpCalled.Invoke(message);
    }

    public event Action<EStates> onChangeState;
    public void OnchangeState(EStates state)
    {
        onChangeState.Invoke(state);
    }

    public event Action<string> ONModelsSetteds;
    public void SendModelsAvaibles(string modelsAvaibles)
    {
        ONModelsSetteds.Invoke(modelsAvaibles);
    }
}

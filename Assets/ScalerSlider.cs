using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalerSlider : MonoBehaviour
{
    [SerializeField]
    public GameObject currentModel;

    [SerializeField] Button add, less, resetScale, trashButton;

    Vector3 scaleFactor = new Vector3();
    Vector3 firstScaleFactor = new Vector3();

    private void Start()
    {
        EventsManager.instance.onChangeState += SetInteractable;
        EventsManager.instance.onSpawnedObject += SetModel;
    }

    private void SetModel(GameObject model)
    {
        currentModel = model;
        scaleFactor = new Vector3(
            currentModel.transform.localScale.x,
            currentModel.transform.localScale.y,
            currentModel.transform.localScale.z);
        firstScaleFactor = scaleFactor;
    }

    public void Add()
    {
        currentModel.transform.localScale += scaleFactor * 0.1f;
    }

    public void Less()
    {
        currentModel.transform.localScale -= scaleFactor * 0.1f;
    }

    public void ResetScale()
    {
        currentModel.transform.localScale = firstScaleFactor;
    }

    public void DeleteModel()
    {
        Destroy(currentModel);
        EventsManager.instance.OnchangeState(EStates.Idle);
    }

    private void SetInteractable(EStates state)
    {
        if (state == EStates.RotatingAndScalingModel)
        {
            add.interactable = true;
            less.interactable = true;
            resetScale.interactable = true;
            trashButton.interactable = true;
        }
        else
        {
            add.interactable = false;
            less.interactable = false;
            resetScale.interactable = false;
            trashButton.interactable = false;
            currentModel = null;
        }
    }
}

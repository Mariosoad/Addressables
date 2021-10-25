using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndScale3DModel : MonoBehaviour
{
    [SerializeField] GameObject modelToManiputale;
    [SerializeField] float speedMultiplier;

    Vector3 startPosition = new Vector3(0, 0, 0);
    Vector3 endPosition = new Vector3(0, 0, 0);

    bool canManipulateModel;

    public static RotateAndScale3DModel instance;
    public float counter, timeToRotate;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        EventsManager.instance.onSpawnedObject += SetModel;
        EventsManager.instance.onChangeState += SetState;
    }

    private void SetState(EStates state)
    {
        if (state == EStates.RotatingAndScalingModel)
            canManipulateModel = true;
        else
            canManipulateModel = false;
    }

    private void SetModel(GameObject model)
    {
        modelToManiputale = model;
        canManipulateModel = true;
    }

    private void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if (!canManipulateModel)
            return;

        if (modelToManiputale == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (Vector3.Distance(startPosition, GetCurrentPosition()) > 1)
                SetStartPosition();
        }

        if (Input.GetMouseButton(0))
        {
            if (Vector3.Distance(endPosition, GetCurrentPosition()) > 0.3f)
            {
                if (GetCurrentPosition().x < endPosition.x)
                    RotateGameObject(modelToManiputale, GetDistanceStartAndEndPosition(), ESide.Left);
                else
                    RotateGameObject(modelToManiputale, GetDistanceStartAndEndPosition(), ESide.Right);
            }
            endPosition = GetCurrentPosition();
            Debug.Log("Start position: " + startPosition);
            Debug.Log("End position: " + endPosition);
        }
    }

    private float GetDistanceStartAndEndPosition()
    {
        return Vector3.Distance(startPosition, endPosition);
    }

    private void RotateGameObject(GameObject modelToManiputale, float distance, ESide side)
    {
        if (side == ESide.Left)
            modelToManiputale.transform.Rotate(transform.up, distance * Time.deltaTime * speedMultiplier);
        else
            modelToManiputale.transform.Rotate(transform.up, distance * Time.deltaTime * -speedMultiplier);

    }

    private void SetStartPosition()
    {
        startPosition = GetCurrentPosition();
    }

    Vector3 GetCurrentPosition()
    {
        return Input.mousePosition;
    }

}

public enum ESide
{
    Right,
    Left
}

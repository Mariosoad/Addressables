using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples.Inventory;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.AddressableAssets;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager m_RaycastManager;
    [SerializeField] GameObject sceneContainer;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] GraphicRaycaster graphicRaycaster;

    private GameObject instantiatedObjectByAddessable;

    EStates currentState;

    private static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    private GameObject spawnedObject;
    private Camera arCam;
    private Touch touch;


    private void Start()
    {
        AddressableInventory.instance
            .GetAddressableModel().LoadAssetAsync();
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        EventsManager.instance.onModelSelected += ModelSelected;
        EventsManager.instance.onChangeState += SetState;
    }

    private void SetState(EStates state)
    {
        currentState = state;
    }

    private void ModelSelected(int id)
    {
        // spawnedObject = Inventory.instance.GetModelById(id);
        // objectToSpawn = Inventory.instance.GetModelById(id);
    }

    private void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        touch = Input.GetTouch(0);

        if (IsUITouch(touch))
        {
            return;
        }

        if (currentState == EStates.RotatingAndScalingModel)
            return;

        if (m_RaycastManager.Raycast(touch.position, s_Hits))
        {            
            Pose hitPose = s_Hits[0].pose;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCam.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    SpawnPrefab(hitPose.position, hitPose.rotation);
                }
            }

        }
    }

    private void SpawnPrefab(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        // if (objectToSpawn == null)
        // {
        //     EventsManager.instance.OnShowPopUp("Seleccione un modelo del inventario");
        //     return;
        // }

        StartCoroutine(Spawn(spawnPosition, spawnRotation));
    }

    IEnumerator Spawn(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        var ad = AddressableInventory.instance
            .GetAddressableModel()
            .InstantiateAsync(spawnPosition, spawnRotation, sceneContainer.transform);
        instantiatedObjectByAddessable = ad.Result as GameObject;
        EventsManager.instance.OnSpawnObject(instantiatedObjectByAddessable);
        EventsManager.instance.OnchangeState(EStates.RotatingAndScalingModel);
        yield break;
    }

    private bool IsUITouch(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = touch.position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, results);

        return results.Count > 0;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AlertSmallRoom : MonoBehaviour
{
    [SerializeField] Text textDebug;

    [SerializeField] GameObject alertPopUp;
    bool popUpActive;
    float timer;

    [SerializeField] float minDistanceToShowPopUp;

    void Start()
    {
        EventsManager.instance.OnGetDistanceToSpawnedObject += ShowPopUpOnSmallDistance;
    }

    private void ShowPopUpOnSmallDistance(float distance, GameObject go)
    {
        if (distance < minDistanceToShowPopUp)
        {
            Destroy(go);
            EventsManager.instance.OnShowPopUp("El objeto es muy grande para el" +
                " espacio actual, aléjese o busque un lugar más grande.");

            //alertPopUp.SetActive(true);
            //popUpActive = true;
            //timer = 3;
        }
    }

}

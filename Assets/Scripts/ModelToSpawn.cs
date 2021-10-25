using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ModelToSpawn : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        CheckDistanceToOtherModels();
    }

    private void CheckDistanceToOtherModels()
    {
        ModelToSpawn[] models = FindObjectsOfType<ModelToSpawn>();
        foreach (var item in models)
        {
            if (item != this && Vector3.Distance(transform.position, item.transform.position) < 1)
            {
                EventsManager.instance.OnShowPopUp("No puedes colocar dos modelos 3D en un mismo lugar");
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ModelToSpawn>())
        {
            EventsManager.instance.OnShowPopUp("No puedes colocar dos modelos 3D en un mismo lugar");
            Destroy(gameObject);
        }
    }

}

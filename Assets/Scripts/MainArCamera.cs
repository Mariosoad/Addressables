using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MainArCamera : MonoBehaviour
{
    GameObject lastObjectSpawned;
    [SerializeField] Text debugText;

    private void Start()
    {
        EventsManager.instance.onSpawnedObject += GetDistanceToSpawnedObject;
    }

    void GetDistanceToSpawnedObject(GameObject go)
    {
        lastObjectSpawned = go;
        EventsManager.instance.GetDistanceToSpawnedObject(
            Vector3.Distance(transform.position, lastObjectSpawned.transform.position), go);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position.Set(transform.position.x, 0.0f, transform.position.z);
    }
}

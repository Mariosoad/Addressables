using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoUnableByTime : MonoBehaviour
{
    float timer;
    [SerializeField] float timeToUnable;
    private void OnEnable()
    {
        timer = timeToUnable;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

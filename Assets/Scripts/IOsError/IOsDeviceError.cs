using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IOsDeviceError : MonoBehaviour
{
    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            SceneManager.LoadScene(2);
    }
}

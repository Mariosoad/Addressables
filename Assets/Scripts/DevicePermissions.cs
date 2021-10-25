using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
#if PLATFORM_ANDROID
using UnityEngine.Android;
using UnityEngine.SceneManagement;
#endif

public class DevicePermissions : MonoBehaviour
{
    [SerializeField]
    GameObject dialog;

    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            SceneManager.LoadScene(1);

#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
#endif
    }

    void OnGUI()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {            
            dialog.SetActive(true);
            return;
        }
#endif
    }

    private void Update()
    {
#if PLATFORM_ANDROID
        if (Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            SceneManager.LoadScene(1);
        }
#endif
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void RequestPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }
}
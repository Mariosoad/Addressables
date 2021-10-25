using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainButtonsFunctions : MonoBehaviour
{
    public GameObject scrollView;
    public Slider scaleSlider;
    public Slider rotSlider;
    public Button screenShot;
    public Button reset;
    public Camera cam;
    private string imagePath;

    public void OpenScrollList()
    {
        scrollView.SetActive(true);
    }

    public void CloseScrollList()
    {
        scrollView.SetActive(false);
    }

    public void OnScaleButtonPressed()
    {
        //add.interactable = !add.interactable;
        reset.interactable = !reset.interactable;
        screenShot.interactable = !screenShot.interactable;
        rotSlider.interactable = !rotSlider.interactable;

        scaleSlider.gameObject.SetActive(!scaleSlider.gameObject.activeInHierarchy);
    }
    public void OnScreenShotButtonClicked()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        Texture2D photo = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        Camera.main.targetTexture = rt;
        cam.targetTexture = rt;

        Camera.main.Render();

        cam.Render();

        RenderTexture.active = rt;

        photo.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        RenderTexture.active = null;
        Camera.main.targetTexture = null;
        cam.targetTexture = null;

        Destroy(rt);
        photo.Apply();

        var bytes = photo.EncodeToPNG();
        Destroy(photo);

        imagePath = System.IO.Path.Combine(Application.persistentDataPath, "Crucijuegos" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".png");

        Debug.Log("Picture stored in: " + imagePath);

        Debug.LogWarning("Photo in " + imagePath);

        System.IO.File.WriteAllBytes(imagePath, bytes);

        yield return new WaitForEndOfFrame(); 
        
        NativeGallery.SaveImageToGallery(imagePath, "Crucijuegos", DateTime.Now.ToString("MMddyyyyHHmmss") + ".png");
    }
}

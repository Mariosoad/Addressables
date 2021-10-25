using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour
{

    public API api;
    public GameObject loadingScreen;
    public GameObject scrollList;
    public Slider scaleSlider;
    public Slider rotSlider;

    private void Start()
    {
        scaleSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    public void LoadContent(string name)
    {
        //loadingScreen.SetActive(true);

        //api.GetBundleObject(name, OnContentLoaded, transform);
        scrollList.SetActive(false);
    }

    void OnContentLoaded(GameObject content)
    {
        OnItemLoaded();
        Debug.Log("Loaded: " + content.name);
    }

    public void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        transform.localEulerAngles = new Vector3(1.0f, 1.0f, 1.0f);
        rotSlider.gameObject.SetActive(false);
    }

    public void OnSliderValueChanged(float newValue)
    {
        transform.localScale = new Vector3(newValue, newValue, newValue);
    }

    void OnItemLoaded()
    {
        loadingScreen.SetActive(false);
        scrollList.SetActive(false);
    }
}

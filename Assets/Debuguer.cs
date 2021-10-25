using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debuguer : MonoBehaviour
{
    [SerializeField]
    ScalerSlider scaleSlider;

    [SerializeField] Text debugText; 

    private void Update()
    {
        debugText.text = scaleSlider.currentModel.name;
    }

}

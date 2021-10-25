using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
public class RemoteSettinsHandler : MonoBehaviour
{
    public struct appAtributes{}
    public struct userAtributes{}
    
    
    private void Start()
    {
        // Add this class's updated settings handler to the RemoteSettings.Updated event.
        ConfigManager.FetchCompleted += Setmodels;
        ConfigManager.FetchConfigs<userAtributes, appAtributes>(new userAtributes(), new appAtributes());
    }

    private void Setmodels(ConfigResponse obj)
    {
        string modelsAvaibles = ConfigManager.appConfig.GetString("modelsAvaibles");
        Debug.Log("Estos son los modelos disponibles: " + modelsAvaibles);
        EventsManager.instance.SendModelsAvaibles(modelsAvaibles);
    }
}

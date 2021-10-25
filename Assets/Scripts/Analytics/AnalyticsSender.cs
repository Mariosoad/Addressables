using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class AnalyticsSender : MonoBehaviour
{
    private void Start()
    {
        EventsManager.instance.onSpawnedObject += ReportModelName;
    }

    public void ReportModelName(GameObject model)
    {
        AnalyticsEvent.Custom("modelPlaced", new Dictionary<string, object>
    {
        { "modelName", model.name }
    });
    }
}

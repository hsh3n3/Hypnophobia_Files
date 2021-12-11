using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogHandler : MonoBehaviour
{
    [HideInInspector]
    public float defaultDensity, currentDensity;
    [HideInInspector]
    public Color defaultColor, currentColor;

    private void Start()
    {
        defaultDensity = RenderSettings.fogDensity;
        defaultColor = RenderSettings.fogColor;
        currentDensity = defaultDensity;
        currentColor = defaultColor;
    }
}

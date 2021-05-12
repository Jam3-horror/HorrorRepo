using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [Header("Light Flicker Setup")]
    public float flickerChance = 0;
    public float flickerTime = 0;
    [SerializeField]private Light lightToFlicker;

    private void Start() 
    {
        lightToFlicker = this.GetComponent<Light>();

        InvokeRepeating("FlickerLight", 0, flickerTime);
    }

    void FlickerLight()
    {
        if(Random.Range(0, 100) < flickerChance)
        {
            lightToFlicker.enabled = !lightToFlicker.enabled;
        }
    }
}

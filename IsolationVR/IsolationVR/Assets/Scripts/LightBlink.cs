using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    Light light;
    float timeTillBlink;

    private void Start()
    {
        light = GetComponent<Light>();
    }
    private void Update()
    {
        float countdown = timeTillBlink -= Time.deltaTime;
        if (countdown <= 0)
        {
            if (light.enabled)
            {
                light.enabled = false;
            }else
            {
                light.enabled = true;
            }
            ResetTime();
        }
    }

    public void ResetTime()
    {
        timeTillBlink = Random.Range(0.1f, 1f);
    }
}

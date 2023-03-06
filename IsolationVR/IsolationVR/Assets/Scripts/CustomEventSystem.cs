using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventSystem : MonoBehaviour
{
    public static CustomEventSystem ces;

    private void Start()
    {
        ces = this;
    }

    public event Action OnHealthChange;
    [HideInInspector] public float h; [HideInInspector] public float mh; [HideInInspector] public float ph;
    public void HealthChange(float health, float maxHealth, float percentageHealth)
    {
        h = health;
        mh = maxHealth;
        ph = percentageHealth;
        if (OnHealthChange != null)
            OnHealthChange();
    }
}

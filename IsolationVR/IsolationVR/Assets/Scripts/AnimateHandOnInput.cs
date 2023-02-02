using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimAction;
    public InputActionProperty gripAnimAction;
    public Animator handAnimator;

    void FixedUpdate()
    {
        float trigVal = pinchAnimAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", trigVal);

        float gripVal = gripAnimAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripVal);
    }
}

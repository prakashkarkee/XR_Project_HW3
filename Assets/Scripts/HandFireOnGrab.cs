using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class HandFireOnGrab : MonoBehaviour
{
    public ParticleSystem leftFire;
    public ParticleSystem rightFire;

    XRGrabInteractable grab;

    void OnEnable()
    {
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(OnGrabbed);
        grab.selectExited.AddListener(OnReleased);
    }

    void OnDisable()
    {
        if (grab == null) return;
        grab.selectEntered.RemoveListener(OnGrabbed);
        grab.selectExited.RemoveListener(OnReleased);
    }

    void OnGrabbed(SelectEnterEventArgs _)
    {
        Debug.Log("Gun grabbed -> Fire ON");
        Toggle(leftFire, true);
        Toggle(rightFire, true);
    }

    void OnReleased(SelectExitEventArgs _)
    {
        Debug.Log("Gun released -> Fire OFF");
        Toggle(leftFire, false);
        Toggle(rightFire, false);
    }

    void Toggle(ParticleSystem ps, bool on)
    {
        if (!ps) { Debug.LogWarning("Fire particle reference missing"); return; }

        if (on) ps.Play(true);
        else ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
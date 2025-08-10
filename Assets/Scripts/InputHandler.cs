using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : IInteractionHandler, IFlashlightInputHandler
{
    public event Action interactionTriggered;
    public event Action flashlightTriggered;

    public void OnInteraction()
    {
        interactionTriggered?.Invoke();
    }

    public void OnFlashlight()
    {
        flashlightTriggered?.Invoke();
    }
}

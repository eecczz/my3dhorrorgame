using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private InputHandler inputHandler;
    public void Init(InputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
        this.inputHandler.flashlightTriggered += Flashlight;
    }
    private void OnDisable()
    {
        inputHandler.flashlightTriggered -= Flashlight;
    }

    public void Flashlight()
    {
        Debug.Log("d");
    }
}

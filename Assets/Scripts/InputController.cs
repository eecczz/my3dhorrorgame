using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InteractionController interactionController;
    private FlashlightController flashlightController;
    private static InputHandler inputHandler;
    [SerializeField] InputActionAsset inputActions;
    private InputAction interactionAction;
    private InputAction flashlightAction;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        interactionAction = inputActions.FindAction("Interaction");
        flashlightAction = inputActions.FindAction("FlashLight");
        inputHandler = new InputHandler();
        interactionController = GetComponent<InteractionController>();
        flashlightController = GetComponent<FlashlightController>();
        interactionController.Init(inputHandler);
        flashlightController.Init(inputHandler);
    }

    private void Update()
    {
        if (flashlightAction.IsPressed())
        {
            inputHandler.OnFlashlight();
        }
        if (interactionAction.IsPressed())
        {
            inputHandler.OnInteraction();
        }
    }
}
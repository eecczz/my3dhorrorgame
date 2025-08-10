using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private RectTransform interactionUI;
    [SerializeField] private RectTransform equipUI;
    private InputHandler inputHandler;
    public InteractObject interactObject {  get; private set; }
    private EquipController equipController;

    private void Awake()
    {
        equipController = GetComponent<EquipController>();        
    }

    public void Init(InputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
        this.inputHandler.interactionTriggered += Interaction;    
    }

    private void OnDisable()
    {
        inputHandler.interactionTriggered -= Interaction;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.gameObject.layer == 6)
            {
                interactObject = hit.collider.GetComponent<InteractObject>();
                interactionUI.gameObject.SetActive(true);
            }
            else
            {
                interactionUI.gameObject.SetActive(false);
            }
            if (hit.collider.gameObject.layer == 7)
            {
                interactObject = hit.collider.GetComponent<InteractObject>();
                equipUI.gameObject.SetActive(true);
            }
            else
            {
                equipUI.gameObject.SetActive(false);
            }
        }
    }

    public void Interaction()
    {
        if (interactObject && interactObject.gameObject.layer == 7)
        {
            Item item = interactObject.GetComponent<Item>();
            equipController.OnEquip(item);
        }
    }
}

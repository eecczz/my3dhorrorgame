using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class EquipController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private int equippedItemId;
    [SerializeField] private Transform handGunSocket;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
    }

    private void SetEquippedItemId(int itemId)
    {
        equippedItemId = itemId;
    }

    public void OnEquip(Item dropItem)
    {
        SetEquippedItemId(dropItem.itemId);
        if (dropItem.objectType == Enum.ObjectType.Handgun.ToString())
        {
            anim.SetBool("handgunEquipped", true);
            CarryItem(dropItem, handGunSocket);
        }
    }

    private void CarryItem(Item dropItem, Transform socket)
    {
        InventoryController.Instance.AddItem(dropItem.itemId);
        Item item = Resources.Load<Item>($"Prefab/{dropItem.itemId}");
        if (item == null)
        {
            Debug.LogWarning($"Item '{dropItem.itemId}' not found in Resources/Prefab/");
            return;
        }
        Transform equipItem = Instantiate(item.transform);
        equipItem.SetParent(socket);
        equipItem.localPosition = Vector3.zero;
        equipItem.localRotation = Quaternion.identity;
        Destroy(dropItem.gameObject);
    }
}

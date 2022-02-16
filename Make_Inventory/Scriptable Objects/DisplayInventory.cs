using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();

    [Header("Inventory")]
    [Tooltip("Inventory Prefab")]
    public GameObject inventoryPrefab;
    [Tooltip("Inventory Database")]
    public InventoryObject inventory;
    [Tooltip("Left hand position")]
    public Transform left_hand;
    [Tooltip("Inventory Prefab Instantiate Start position X")]
    public int X_START;
    [Tooltip("Inventory Prefab Instantiate Start position Y")]
    public int Y_START;
    [Tooltip("Inventory Prefab Interval X")]
    public int X_SPACE_BETWEEN_ITEM;
    [Tooltip("Inventory Interval Column")]
    public int NUMBER_OF_COLUMN;
    [Tooltip("Inventory Prefab Interval Y")]
    public int Y_SPACE_BETWEEN_ITEMS;

    public GroundItem[] Key_Item;
    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
    void Awake ()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }
    public void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnDragEnd(obj); });

            itemsDisplayed.Add(obj, inventory.Container.Items[i]);
        }
    }
    public void UpdateSlots()
    {

        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if (_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }
    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
            mouseItem.hoverItem = itemsDisplayed[obj];
    }
    public void OnExit(GameObject obj)
    {
        mouseItem.hoverObj = null;
        mouseItem.hoverItem = null;
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(20, 20);
        mouseObject.transform.SetParent(transform.parent);
        if (itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            img.raycastTarget = false;
        }
        mouseItem.obj = mouseObject;
        mouseItem.item = itemsDisplayed[obj];
    }
    public void OnDragEnd(GameObject obj)
    {
        for (int i = 1; i < Key_Item.Length; i++)
        {
            //print(itemsDisplayed[obj].item.Id);
            //print(Key_Item[i].item.id);
            if (itemsDisplayed[obj].item.Id == Key_Item[i].item.id)
            {
                if(i == 3)
                    Instantiate(Key_Item[i], new Vector3(left_hand.position.x,left_hand.position.y+5,left_hand.position.z), Quaternion.identity);
                else
                    Instantiate(Key_Item[i], new Vector3(left_hand.position.x+1, left_hand.position.y, left_hand.position.z), Quaternion.identity);
                break;
            }
        }
        /*if (itemsDisplayed[obj].amount == 1 && itemsDisplayed[obj].item.Id != -1)
            inventory.RemoveItem(itemsDisplayed[obj].item);
        else if(itemsDisplayed[obj].item.Id != -1)
            itemsDisplayed[obj].amount -= 1;*/
        if (itemsDisplayed[obj].amount == 1)
            inventory.RemoveItem(itemsDisplayed[obj].item);
        else
            itemsDisplayed[obj].amount -= 1;

        Destroy(mouseItem.obj);
        mouseItem.item = null;
    }
    public void OnDrag(GameObject obj)
    {
        if (mouseItem.obj != null)
        {
            // 드래그가 인식되는 위치를 오른쪽 컨트롤러 위치로 지정
            mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }


    public Vector3 GetPosition(int i)
    {
        //print(X_START + ((X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)))+"  "+ (Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)))+"  "+ 0f);
        return new Vector3((X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN))), (Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN))), 0f);
    }
}
public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
}
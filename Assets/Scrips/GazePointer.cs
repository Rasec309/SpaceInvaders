using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class GazePointer : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactableLayer;
    private EventSystem eventSystem;
    private PointerEventData pointerEventData;
    private GameObject currentObject;
    private void Start ()
    {
        eventSystem = EventSystem.current;
        if (eventSystem == null)
        {
            GameObject eventSystemObject = new GameObject("EventSystem");
            eventSystem = eventSystemObject.AddComponent<EventSystem>();
            eventSystemObject.AddComponent<StandaloneInputModule>();
        }
        pointerEventData = new PointerEventData (eventSystem);
    }
    GameObject GetFirstValid (List<RaycastResult> raycastResults)
    {
        foreach (var result in raycastResults)
        {
            if (((1 << result.gameObject.layer) & interactableLayer) != 0)
            {
                return result.gameObject;
            }
        }
        return null;
    }
    private void Update()
    {
        pointerEventData.position = new Vector2 (Screen.width / 2, Screen.height / 2);
        List <RaycastResult> raycastResults = new List<RaycastResult>();
        eventSystem.RaycastAll(pointerEventData, raycastResults);
        GameObject hitObject = GetFirstValid (raycastResults);
        if (currentObject != hitObject)
        {
            if (currentObject != null)
            {
                currentObject.SendMessage("OnPointerExit", pointerEventData, SendMessageOptions.DontRequireReceiver);
            }
            if (hitObject != null)
            {
                hitObject.SendMessage("OnPointerEnter", pointerEventData, SendMessageOptions.DontRequireReceiver);
            }
            currentObject = hitObject;
        }
        if (Input.GetMouseButtonDown(0) && currentObject != null)
        {
            currentObject.SendMessage("OnPointerClick", pointerEventData, SendMessageOptions.DontRequireReceiver);
        }
    }
}
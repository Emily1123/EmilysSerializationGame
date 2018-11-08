using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MachineMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //GameObject currentHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //currentHover = eventData.pointerCurrentRaycast.gameObject;
            // Cursor.lockState = CursorLockMode.Confined;
            // Cursor.visible = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = false;
        //currentHover = null;
    }
}

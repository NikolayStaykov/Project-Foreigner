using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClickDetector : MonoBehaviour, IPointerClickHandler
{
    private GrapplingHookModule _module;
    public void Awake()
    {
        this._module = this.gameObject.GetComponentInParent<GrapplingHookModule>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)
        {
            _module.OnDoubleClickAction();
        }
    }
}

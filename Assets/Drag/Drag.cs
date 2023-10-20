using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    public static Vector2 EndPos;
    [SerializeField] public Transform DropBox;
    [SerializeField] bool Drop = false;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {

        EndPos = DropBox.transform.position;

        DefaultPos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;


    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if(Drop == false)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = DefaultPos;
        }
        else if(Drop == true)
        {
            
            this.transform.position = EndPos;
        }
        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�ǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤǤ�");
        Drop = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    public Transform Box;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;


    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 만약 Box 태그를 가진 오브젝트와 충돌한 경우
        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePos);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Box"))
            {
                // Box 태그를 가진 오브젝트와 충돌한 경우 해당 오브젝트의 위치로 이동
                this.transform.position = Box.transform.position;
                return; // 이미 Box와 충돌한 경우에는 더 이상 검사할 필요가 없으므로 종료
            }
        }
    }
}

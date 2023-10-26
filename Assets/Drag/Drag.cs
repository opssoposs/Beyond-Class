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

        // ���� Box �±׸� ���� ������Ʈ�� �浹�� ���
        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePos);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Box"))
            {
                // Box �±׸� ���� ������Ʈ�� �浹�� ��� �ش� ������Ʈ�� ��ġ�� �̵�
                this.transform.position = Box.transform.position;
                return; // �̹� Box�� �浹�� ��쿡�� �� �̻� �˻��� �ʿ䰡 �����Ƿ� ����
            }
        }
    }
}

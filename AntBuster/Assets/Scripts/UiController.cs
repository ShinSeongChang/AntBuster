using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerMoveHandler
{
    private bool isClick = false;
    public Canvas Ui = default;
    public GameObject hammePrefab = default;

    public static Transform target = null;

    private void Awake()
    {       
        Ui = GetComponentInParent<Canvas>();
    }

    public void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (target != null)
        {
            target.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {


    }

    public void OnPointerDown(PointerEventData eventData)
    {

        /*Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, 0f);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "HammerTower")
            {
                Debug.Log("해머타워를 클릭했습니다.");
            }
        }*/
        target = transform;
    }

    public void OnPointerMove(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (target != null)
        {
            target = null;
        }
    }

}

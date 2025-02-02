using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class UI_Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject cursor;
    float _radius;
    Vector2 _touchPos;


    void Awake()
    {
        _radius = background.GetComponent<RectTransform>().sizeDelta.y / 2;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        background.transform.position = eventData.position;
        cursor.transform.position = eventData.position;
        _touchPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    { 
        cursor.transform.position = _touchPos;
        
        Managers.Game.MoveDir = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var touchDir = (eventData.position - _touchPos);
        var moveDist = Mathf.Min(touchDir.magnitude, _radius);
        var moveDir = touchDir.normalized;
        
        var newPosition = _touchPos + moveDir * moveDist;
        cursor.transform.position = newPosition;
        
        Managers.Game.MoveDir = moveDir;
    }
}

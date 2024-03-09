using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform Stick;
    public RectTransform Lever;

    public Vector2 input;
    private Vector2 minusVec;
    private float AlphaTarget;

    public Vector2 inputVec { get; private set; }

    private void Awake()
    {
        
    }

    private void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //var s = SceneManager.

        Stick.localPosition = eventData.position - minusVec - (Stick.sizeDelta / 2);
        input = eventData.position - (Vector2)Stick.localPosition - minusVec - (Stick.sizeDelta / 2);
        inputVec = input.normalized;
        inputVec *= input.magnitude / (Stick.rect.width * 0.5f);
        Lever.localPosition = Vector2.ClampMagnitude(input, Stick.rect.width * 0.5f);
        AlphaTarget = 0.3f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        input = eventData.position - Stick.anchoredPosition - minusVec - (Stick.sizeDelta / 2);
        inputVec = input.normalized;
        inputVec *= Vector2.ClampMagnitude(input, Stick.rect.width * 0.5f).magnitude / (Stick.rect.width * 0.5f);
        Lever.anchoredPosition = Vector2.ClampMagnitude(input, Stick.rect.width * 0.5f);
        AlphaTarget = 0.3f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        input = Vector2.zero;
        inputVec = Vector2.zero;
        Lever.anchoredPosition = input;
        AlphaTarget = 0;
    }
}

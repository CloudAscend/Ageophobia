using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CustomBox : MonoBehaviour
{
    private Image customImage;
    private RectTransform rectTransform;
    private void Awake()
    {
        customImage = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void InitImage(Sprite customSprite) //ScriptableObject
    {
        customImage.sprite = customSprite;
    }

    public void MoveTo(float movePoint)
    {
        StartCoroutine(Move(movePoint));
    }

    private IEnumerator Move(float movePoint)
    {
        Vector3 moveVec = rectTransform.anchoredPosition; 

        float curPoint = rectTransform.anchoredPosition.x;
        float addPoint = movePoint / Mathf.Abs(movePoint);
        while (movePoint == Mathf.RoundToInt(curPoint))
        {
            moveVec.y += addPoint * 5 * Time.deltaTime;
            rectTransform.anchoredPosition = moveVec;
            yield return null;
        }
    }

    public void ScaleUp()
    {
        rectTransform.DOScale(1.25f, 1f);
    }

    public void ScaleDown()
    {

    }
}

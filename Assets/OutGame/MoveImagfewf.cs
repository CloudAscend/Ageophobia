using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveImagfewf : MonoBehaviour
{
    private RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        transform.DOMove(Vector3.zero, 1);
    }
}

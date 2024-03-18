using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CustomSelect : MonoBehaviour
{
    [SerializeField] private Text selectedButton;
    [SerializeField] private Transform customs;
    [SerializeField] private List<CustomBox> customBox; // -> ScriptableObject

    //[SerializeField] private [] //CrocodileCustoms -> ScriptableObject

    private float moveDir;

    private void Start()
    {
        for (int i = 0; i < customBox.Count; i++)
        {
            var box = Instantiate(customBox[i], transform);
            box.transform.parent = customs;
        }
    }

    public void OnLeft()
    {
        MoveImages(false);
    }

    public void OnRight()
    {
        MoveImages(true);
    }

    private void MoveImages(bool isRight)
    {
        moveDir = 1;

        if (isRight) moveDir *= -1;

        for (int i = 0; i < 10; i++)
            customs.DOMoveX(customs.position.x + moveDir * 10, 0.1f);

        //while (Mathf.Round(customs.position.x) != moveDir)
        //{
        //    customs.DOMoveX(customs.position.x + moveDir, 0.1f);
        //}
        //Debug.Log(customs.position.x);
    }
}

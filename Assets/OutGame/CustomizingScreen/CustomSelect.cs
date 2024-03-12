using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CustomSelect : MonoBehaviour
{
    [SerializeField] private Text selectedButton;

    [SerializeField] private Image[] crocodileImage;

    //0(-1000), 1(0), 2(1000) -> 1(-1000), 2(0), 0(1000)

    //[SerializeField] private [] //CrocodileCustoms -> ScriptableObject

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
        //float movePos

        
    }
}

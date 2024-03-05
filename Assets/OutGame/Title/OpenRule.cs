using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenRule : MonoBehaviour
{
    [SerializeField]
    private GameObject RuleBook;
    // Start is called before the first frame update
    public void Open()
    {
        RuleBook.SetActive(true);
    }
    public void Close()
    {
        RuleBook.SetActive(false);
    }
}
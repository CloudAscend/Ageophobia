using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RuleBook : MonoBehaviour
{
    [SerializeField]
    private GameObject ruleBook;
    int x = 1;
    int y = 1;
    int z = 1;
    float s = 0.5f;
    private void Start()
    {
        ruleBook.transform.DOScale(new Vector3(0, 0, 0), 0);
    }

    // Start is called before the first frame update
    public void OpenRuleBook()
    {
        ruleBook.SetActive(true);
        ruleBook.transform.DOScale(new Vector3(x, y, z), s);
    }
    public void CloseRuleBook()
    {
        
        ruleBook.transform.DOScale(new Vector3(0, 0, 0), s);
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : ItemBase
{
    protected override void GetItem()
    {
        HP.instance.hp += 10;
        gameObject.SetActive(false);
    }
}

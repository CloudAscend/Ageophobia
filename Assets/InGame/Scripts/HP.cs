using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public static HP instance;

    [SerializeField] private Image hpImage;
    [SerializeField] private Text hpText;

    public int maxHp;
    public float hp;

    public bool isCount;

    //Temp
    [SerializeField] private Animator anim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        hp = maxHp;

        isCount = true;
    }

    private void FixedUpdate()
    {
        Countdown();
    }

    private void Countdown()
    {
        if (hp <= 0)
        {
            GameOver();
            return;
        }

        if (isCount)
        {
            hp -= Time.deltaTime;
        }

        hp = Mathf.Clamp(hp, 0, maxHp);
        hpImage.fillAmount = hp / maxHp;
        hpText.text = "HP : " + (Mathf.Round(hp));
    }

    private void GameOver()
    {
        anim.SetBool("Death", true);
    }
}

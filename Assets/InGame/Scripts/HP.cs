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
    [SerializeField] private Text stateText;

    public int maxHp;
    public float hp;

    public bool isCount;

    //Temp
    [SerializeField] private Animator anim;
    [SerializeField] private Image image;
    [SerializeField] private Text text;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        hp = maxHp;

        //Temp
        image.enabled = false;
        text.enabled = false;
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
        else
        {
            hp += Time.deltaTime;
        }

        hp = Mathf.Clamp(hp, 0, maxHp);
        hpImage.fillAmount = hp / maxHp;
        hpText.text = "HP : " + (Mathf.Round(hp));

        if (hp <= 5) //Temp
        {
            hpImage.color = Color.red;
            hpText.color = Color.red;
        }
        else
        {
            hpImage.color = Color.yellow;
            hpText.color = Color.yellow;
        }
    }

    private void GameOver()
    {
        if (isCount) //Temp
        {
            isCount = false;
            StartCoroutine(Gameover());
        }
    }

    //Temp
    private IEnumerator Gameover()
    {
        anim.SetBool("Death", true);

        yield return new WaitForSeconds(2f);

        image.enabled = true;
        text.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            isCount = false;
            stateText.text = "물 밖은 위험하단다.";
            stateText.color = Color.blue;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            isCount = true;
            stateText.text = "탈수 증상";
            stateText.color = Color.yellow;
        }
    }
}

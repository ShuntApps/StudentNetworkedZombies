using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

    public Health healthScript;
    public Text healthTxt;
    public Slider healthBar;

    public Text scoreNum;
    public Text timeNum;
    static int score;

    GameObject losePanel;

    public static void updateScore(int amount)
    {
        score += amount;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();
        timeNum.text = "" + (int)Time.time;
        scoreNum.text = score + "";


        if (healthScript.IsDead)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Use this for initialization
    void Start () {
        GameManager manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        healthBar =manager.playerHealth;
        healthTxt = manager.playerHealthTxt;
        scoreNum = manager.score;
        timeNum=manager.timeTxt;

        healthBar.maxValue = healthScript.getMaxHealth();
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();

        losePanel = manager.losePanel;
        losePanel.SetActive(false);

        StartCoroutine("updateUI");
    }



    IEnumerator updateUI()
    {
       

        if (healthScript.IsDead)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("updateUI");
    }
}

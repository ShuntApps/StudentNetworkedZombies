using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public Slider playerHealth;
    public Text score;
    public Text playerHealthTxt;
    public Text timeTxt;
    public bool won;

    public GameObject winPanel;
    public GameObject losePanel;

    public GameObject helicopter;

    public static int amountKilled;

    // Use this for initialization
    void Start()
    {
        winPanel.SetActive(false);
        amountKilled = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 180)
        {
            won = true;
        }

        if (won == true)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
        if(amountKilled>15)
        {
            EventManager.TriggerEvent("zombiesKilled");
        }
        else if (amountKilled > 30)
        {
            helicopter.GetComponent<Animation>()["CopterArrive"].wrapMode = WrapMode.ClampForever;
            helicopter.GetComponent<Animation>().Play("CopterArrive");
        }
    }
}

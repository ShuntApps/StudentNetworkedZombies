using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public void loadMain()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}

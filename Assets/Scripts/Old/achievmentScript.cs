using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievmentScript : MonoBehaviour {

    public GameObject deathBadge;
    public GameObject surviveBadge;

	// Use this for initialization
	void Start () {
        deathBadge.SetActive(false);
    }

    void OnEnable()
    {
        EventManager.StartListening("zombiesKilled", revealDeathBadge);
    }

    void OnDisable()
    {
        EventManager.StopListening("zombiesKilled", revealDeathBadge);
    }

    void revealDeathBadge()
    {
        deathBadge.SetActive(true);
    }
}

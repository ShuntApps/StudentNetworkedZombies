using UnityEngine;
using System.Collections;

public class CollectScript : MonoBehaviour {

    //holds whether you've picked the thing up
    public bool thingPickedUp;
    public int score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            thingPickedUp = true;
            score += 1000;
            print("pickup");
            Destroy(other.gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    [SerializeField] GameObject thingToSpawn;
    [SerializeField] float delayBetweenSpawns=2.0f;
    [SerializeField] float timeOfNextSpawn=1f;
    public int amountToSpawn=10;
    static int amountSpawned=1;
	
    void Start()
    {
        Instantiate(thingToSpawn, transform.position, Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {
        if (Time.time >= timeOfNextSpawn&&amountSpawned<amountToSpawn)
        {
            Instantiate(thingToSpawn,transform.position,Quaternion.identity);
            timeOfNextSpawn = Time.time + delayBetweenSpawns;
            amountSpawned++;
        }
	}
    
    static public void EnemyDie()
    {
        amountSpawned--;
    }
}

using UnityEngine;
using System.Collections;

public class navScript : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent agent;
	[SerializeField] GameObject[] target;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		target= GameObject.FindGameObjectsWithTag("Waypoint");
	}
	
	// Update is called once per frame
	void Update () {
		int randomNum = Random.Range(0,target.Length-1);
		agent.SetDestination(target[randomNum].transform.position);
	}
}

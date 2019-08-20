using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent agent;
    public GameObject waypoints;
	// List or Array of points- starts at number 0
	Transform[] points;
	public int destPoint=0;

	// Use this for initialization
	void Start () {
        points = waypoints.GetComponentsInChildren<Transform>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//Can turn off autobraking to not stop between waypoints
		agent.autoBraking = false;
		GotoNextPoint ();
	}

	void GotoNextPoint()
	{
		if (points.Length == 0) {
			return;		}

		agent.SetDestination (points [destPoint].position);
		//if goes higher than the total number of waypoints -> go back to start of array
		destPoint = (destPoint + 1) % points.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance < 0.5f) {
			GotoNextPoint ();
		}
	}
}

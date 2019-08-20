using UnityEngine;
using System.Collections;

public class RTSStyle : MonoBehaviour {

	public Transform target;
	UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButton (0)) {
			//holds the info about raycast
			RaycastHit hit;

			//launch a raycast from the middle of the camera to a point
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,100))
				{
					agent.destination = hit.point;
				}
		}
	}
}

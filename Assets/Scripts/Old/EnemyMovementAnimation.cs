using UnityEngine;
using System.Collections;

public class EnemyMovementAnimation : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;

	// Use this for initialization
	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent > ();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //print(agent.velocity.magnitude);
        if (agent)
        {
            anim.SetFloat("Speed", agent.velocity.magnitude);
        }
	}
}

using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

    public enum Behaviours { Patrol, Combat, Heal };
    public Behaviours currBehaviour = Behaviours.Patrol;

    UnityEngine.AI.NavMeshAgent agent;
    public GameObject[] points;
    public int destPoint = 0;

    public Transform player;
    public int chaseDistance;
    public int findDistance;

    public Transform healthPoint;
    Health healthScript;

    void RunBehaviours()
    {
        switch (currBehaviour)
        {
            case Behaviours.Patrol:
                RunPatrolState();
                break;
            case Behaviours.Combat:
                RunCombatState();
                break;
            case Behaviours.Heal:
                RunHealState();
                break;
        }
    }

    void RunPatrolState()
    {
        if(Vector3.Distance(transform.position, player.position)<findDistance)
        {
            currBehaviour = Behaviours.Combat;
        }
        else if (agent.remainingDistance < 0.5f)
        {
            if (points.Length == 0)
            {
                return;
            }
            agent.SetDestination(points[destPoint].transform.position);
            //if goes higher than the total number of waypoints -> go back to start of array
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    void RunCombatState()
    {
        if (Vector3.Distance(transform.position, player.position) > chaseDistance)
        {
            currBehaviour = Behaviours.Patrol;
        }
        else
        {
            agent.SetDestination(player.position);
        }
    }

    void RunHealState()
    {
        agent.SetDestination(healthPoint.position);
        if (agent.remainingDistance < 0.1f )
        {
            currBehaviour=Behaviours.Patrol;
        }
    }

	// Use this for initialization
	void Start () {
        healthScript = GetComponent<Health>();
        agent=GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthPoint = GameObject.FindGameObjectWithTag("Pick Up").transform;
        points = GameObject.FindGameObjectsWithTag("Waypoint");
    }
	
	// Update is called once per frame
	void Update () {
        if (healthScript.getHealth() < 25)
        {
            currBehaviour= Behaviours.Heal;
        }

        RunBehaviours();
	}
}

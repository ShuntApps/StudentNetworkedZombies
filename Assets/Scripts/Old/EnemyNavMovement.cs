using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyNavMovement : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    public float velocity;



    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity= (agent.velocity.magnitude);
        if (target)
        {
            
            agent.SetDestination(target.position);
            
        }
        if ((agent.remainingDistance < (agent.stoppingDistance + 0.5f))&&(target))
        {
           transform.LookAt(target.transform);
           transform.localEulerAngles = new Vector3(0, transform.rotation.y, 0);
        }
        if(agent.velocity.magnitude>0.01f)
        {
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walking", false);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            target = other.transform;
            this.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}
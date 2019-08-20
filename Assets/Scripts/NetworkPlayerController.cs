using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkPlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 10.0F;
    public float rotationSpeed = 50.0F;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float forwards = Input.GetAxis("Vertical") * speed;
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed;
        forwards *= Time.deltaTime;
        rotate *= Time.deltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotate, 0f);
        rb.MovePosition(rb.position + this.transform.forward * forwards);
        rb.MoveRotation(rb.rotation * turn);

        if (forwards != 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Attacking");
            GetComponent<NetworkAnimator>().SetTrigger("Attacking");
        }
    }
}

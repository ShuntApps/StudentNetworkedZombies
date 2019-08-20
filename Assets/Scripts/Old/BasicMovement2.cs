using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

    CharacterController varController;
    [SerializeField]float jumpSpeed = 20.0f;
    [SerializeField]float gravity = 1.0f;
    float yVelocity = 0.0f;
    [SerializeField]float moveSpeed = 5.0f;


    void Start()
    {
        varController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float X = Input.GetAxis("mouseX");
        Vector3 rot = transform.localEulerAngles;
        rot.y += X * 5;
        transform.localEulerAngles = rot;

        float h = Input.GetAxis("horizontal");
        float v = Input.GetAxis("vertical");
        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;
        if (varController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpSpeed;
            }
        }
        else
        {
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;
        velocity = transform.TransformDirection(velocity);
        varController.Move(velocity * Time.deltaTime);
    }
}

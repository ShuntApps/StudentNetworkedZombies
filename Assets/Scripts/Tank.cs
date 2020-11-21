using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Mirror;

public class Tank : NetworkBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;

    [Header("Movement")]
    public float rotationSpeed = 100;

    [Header("Firing")]
    public KeyCode shootKey = KeyCode.Space;
    public GameObject projectilePrefab;
    public Transform projectileMount;

    [Header("Health and UI")]
    [SyncVar(hook = nameof(SetHealth))]
    public int healthValue = 5;
    public TMPro.TextMeshPro healthTxt;
    GameObject localUI;
    Text loseTxt;

    public override void OnStartServer()
    {
        base.OnStartServer();
        SetHealth(healthValue);
    }

    void SetHealth(int newHealth)
    {
        string healthStr = "";
        for(int i=1;i<=newHealth;i++)
        {
            healthStr += "-";
        }
        healthTxt.text = healthStr;
        if (newHealth <= 0)
        {
            healthTxt.text = "Lose";
            if(isLocalPlayer)
            {
                GetComponent<Tank>().enabled = false;
            }
        }
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            loseTxt = GameObject.Find("loseTxt").GetComponent<Text>();
            CameraFollow360.player = transform;
        }
        
    }

    void Update()
    {
        // movement for local player
        if (!isLocalPlayer) return;

        // rotate
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        // move
        float vertical = Input.GetAxis("Vertical");
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        agent.velocity = forward * Mathf.Max(vertical, 0) * agent.speed;
        
        // shoot
        if (Input.GetKeyDown(shootKey))
        {
            CmdFire();
        }
    }

    // this is called on the server
    [Command]
    void CmdFire()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), GetComponent<Collider>());
        NetworkServer.Spawn(projectile);
        RpcOnFire();
    }

    // this is called on the tank that fired for all observers
    [ClientRpc]
    void RpcOnFire()
    {
        
    }

    [Command]
    public void CmdChangeHealth(int amount)
    {
        healthValue = healthValue + amount;
        if (isLocalPlayer)
        {
            Debug.Log("You Lose");
            if (healthValue <= 0)
            {
                loseTxt.text = "You Lose";
            }
            GetComponent<Tank>().enabled = false;

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isLocalPlayer && collision.gameObject.tag == "Bullet")
        {
            Debug.Log("hit "+gameObject);
            CmdChangeHealth(-1);
        }
    }
}



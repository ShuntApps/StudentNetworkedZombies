using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class SetupPlayers : NetworkBehaviour
{
    Animator animator;

    public int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int healthValue = 100;
    public GameObject healthPrefab;
    public Slider healthBar;
    public Transform UIPos;

    [SyncVar(hook = "OnChangeColour")]
    public string playerColour;

    [SerializeField]
    Dropdown clrDropdown;

    public override void OnStartClient()
    {
        base.OnStartClient();
        Invoke("UpdateStats",1);
    }

    void UpdateStats()
    {
        OnChangeColour(playerColour);
        OnChangeHealth(maxHealth);

        clrDropdown.gameObject.SetActive(false);
        GameObject.FindObjectOfType<UpdatedNetworkHud>().showGUI = false;
    }

    Color checkColour(string colour)
    {
        if(colour=="Red")
        {
            return Color.red;
        }
        else if(colour == "Blue")
        {
            return Color.blue;
        }
        else if (colour == "Green")
        {
            return Color.green;
        }
        else if (colour == "Yellow")
        {
            return Color.yellow;
        }
        else if (colour == "Cyan")
        {
            return Color.cyan;
        }
        else if (colour == "Black")
        {
            return Color.black;
        }
        else
        {
            return Color.gray;
        }
    }


    void OnChangeColour(string newColour)
    {
        Renderer[] rends = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in rends)
        {
            if (r.gameObject.name == "Knight")
                r.materials[0].SetColor("_Color", checkColour(newColour));
            
        }
    }

    [Command]
    public void CmdChangeColour(string newColour)
    {
        Renderer[] rends = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in rends)
        {
            if (r.gameObject.name == "Knight")
                r.materials[0].SetColor("_Color", checkColour(newColour));
        }
    }

    void OnChangeHealth(int n)
    {
        healthValue = n;
        healthBar.value = healthValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        clrDropdown = GameObject.FindGameObjectWithTag("DropDownClr").GetComponent<Dropdown>();
        playerColour = clrDropdown.options[clrDropdown.value].text.ToString();

        clrDropdown.onValueChanged.AddListener(delegate
        {
            selectvalue(clrDropdown);
        });

        

        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Running", false);
        if (isLocalPlayer)
        {
            GetComponent<NetworkPlayerController>().enabled = true;
            CameraFollow360.player = this.gameObject.transform;
        }
        else
        {
            GetComponent<NetworkPlayerController>().enabled = false;
        }

        GameObject UIcanvas = Instantiate(healthPrefab, UIPos.position, Quaternion.identity);
        healthBar = UIcanvas.GetComponentInChildren<Slider>();
        UIcanvas.transform.SetParent(UIPos);
        Debug.Log(Time.time + " Start");

        GetComponent<Rigidbody>().isKinematic = !isLocalPlayer;
        if (isLocalPlayer)
        {
            
            CmdChangeHealth(0);
        }
    }

    private void selectvalue(Dropdown clrdropdown)
    {
        Debug.Log((clrDropdown.value.ToString()));
        playerColour = clrDropdown.options[clrDropdown.value].text.ToString();
        CmdChangeColour(clrDropdown.options[clrDropdown.value].text.ToString());
    }


    [Command]
    public void CmdChangeHealth(int amount)
    {
        healthValue = healthValue + amount;
        healthValue= Mathf.Min(healthValue, maxHealth);
        //healthBar.value = healthValue;
        //need to implement respawn
    }

    [ClientRpc]
    public void RpcUpdateHealth()
    {

    }




    private void Update()
    {
            
    }
}

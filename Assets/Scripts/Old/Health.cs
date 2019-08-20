using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] int maximumHealth = 100;
	int currentHealth = 0;
    Animator anim;
    public Renderer renderer;

	void Start () {
		currentHealth = maximumHealth;
        anim = GetComponent<Animator>();
        renderer = GetComponentInChildren<Renderer>();
	}

	public bool IsDead { get{ return currentHealth <= 0; } }

	public int getHealth()
	{
		return currentHealth;
	}

    public int getMaxHealth()
    {
        return maximumHealth;
    }

	public void Damage(int damageValue)
	{
		currentHealth -= damageValue;

		if (currentHealth <= 0) {
            if (gameObject.tag != "Player")
            {
                UIScript.updateScore(50);
               
            }            
		}
	}

    void Update()
    {
        if(IsDead&&!renderer.isVisible)
        {
            Destroy(gameObject);
            GameManager.amountKilled++;
        }
    }
}

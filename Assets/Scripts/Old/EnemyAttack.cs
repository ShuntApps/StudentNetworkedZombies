using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	float nextTimeAttackIsAllowed = -1.0f;

	[SerializeField] float attackDelay = 1.0f;

	[SerializeField] int damageDealt =5;

    Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    [SerializeField] GameObject bloodHit;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player"&&Time.time>=nextTimeAttackIsAllowed) {
			Health playerHealth = other.GetComponent<Health>();
            anim.SetTrigger("Attack");
			playerHealth.Damage(damageDealt);
            
            Vector3 hitDirection = (transform.root.position - other.transform.position).normalized;
            Vector3 hitEffectPos = other.transform.position + (hitDirection * 0.01f) + (Vector3.up * 1.5f);
            Quaternion hitEffectRotation = Quaternion.FromToRotation(Vector3.forward, hitDirection);
            Instantiate(bloodHit, hitEffectPos, hitEffectRotation);

            nextTimeAttackIsAllowed = Time.time + attackDelay;                                       
		}
	}
}


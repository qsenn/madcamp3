using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public BoxCollider damageCollider;
    public BoxCollider pickupCollider;
    public int currentWeaponaDamage = 20;

    private bool canAttackFlag  = false;
    private Health targetHealth;

    private void Awake()
    {
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
        pickupCollider.enabled = true;
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
        pickupCollider.enabled = false;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
        pickupCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        bool attackFlag = collision.gameObject.CompareTag("Player") && damageCollider.enabled;
        canAttackFlag = attackFlag;
            
        if (attackFlag){
            targetHealth = collision.GetComponent<Health>();
        }
        if (collision.tag == "Player" && damageCollider.enabled)
        {
            canAttackFlag = true;
            //targetHealth = collision
        }
    }

    private void OnTriggerEixt(Collider collision)
    {
        if (collision.tag == "Player" && damageCollider.enabled)
        {
            targetHealth = null;
            canAttackFlag = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (targetHealth != null)
            {
                targetHealth.DamagePlayer(currentWeaponaDamage);
            }
        }
    }
}

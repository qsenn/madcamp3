using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttach : MonoBehaviour
{
    public BoxCollider damageCollider;
    public int currentWeaponaDamage = 2;

    [SerializeField] AudioSource handAudio;

    private bool canAttackFlag  = false;
    private Health targetHealth;

    private void Awake()
    {
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
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

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.CompareTag("Player") && damageCollider.enabled)
        {
            targetHealth = null;
            canAttackFlag = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && damageCollider.enabled)
        {
            handAudio.Play();
            
            if (targetHealth != null)
            {
                targetHealth.DamagePlayer(currentWeaponaDamage);
            }
        }
    }
}

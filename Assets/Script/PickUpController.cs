using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] GameObject PickupAnnounce;
    [SerializeField] Transform ItemSlot;

    private bool _canPickupFlag = false;
    private GameObject _pickupTarget;
    private GameObject _grabbingItem;
    private Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        bool itemFlag = collision.gameObject.CompareTag("Item");
        PickupAnnounce.SetActive(itemFlag);
        _canPickupFlag = itemFlag;
        if (itemFlag)
        {
            _pickupTarget = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            PickupAnnounce.SetActive(false);
            _canPickupFlag = false;
            _pickupTarget = null;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.GetComponentInChildren<HandAttach>().EnableDamageCollider();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_grabbingItem)
            {
                _grabbingItem.transform.SetParent(null);
                _grabbingItem.GetComponent<BoxCollider>().isTrigger = false;
                _grabbingItem.GetComponentInChildren<DamageCollider>().DisableDamageCollider();
                _grabbingItem.transform.localEulerAngles = Vector3.zero;
                _grabbingItem.transform.position = transform.position + new Vector3(0f, 2f, 0f);
                _grabbingItem = null;

                gameObject.GetComponentInChildren<HandAttach>().EnableDamageCollider();
            }

            if (_canPickupFlag && _pickupTarget)
            {
                // you can play pickup animation here
                _grabbingItem = _pickupTarget;
                _pickupTarget = null;
                _grabbingItem.GetComponent<BoxCollider>().isTrigger = true;

                _grabbingItem.GetComponentInChildren<DamageCollider>().EnableDamageCollider();
                _grabbingItem.transform.SetParent(ItemSlot);
                _grabbingItem.transform.localEulerAngles = Vector3.zero;
                _grabbingItem.transform.localPosition = Vector3.zero;

                gameObject.GetComponentInChildren<HandAttach>().DisableDamageCollider();

                if (_grabbingItem.GetComponentInChildren<DamageCollider>().currentWeaponaDamage == 30)
                {
                    animator.speed = 0.5f;
                    gameObject.GetComponent<PlayerMovement>().walkSpeed = 4f;
                    gameObject.GetComponent<PlayerMovement>().acceleration = 6f;

                }
                else
                {
                    animator.speed = 1f;
                    gameObject.GetComponent<PlayerMovement>().walkSpeed = 6f;
                    gameObject.GetComponent<PlayerMovement>().acceleration = 10f;
                }

                PickupAnnounce.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("IsAttacking", true);

            if (_grabbingItem != null)
            {
                _grabbingItem.GetComponentInChildren<DamageCollider>().PlayAudio();
            }

        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    
}

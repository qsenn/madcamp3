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
        Debug.Log(collision.gameObject);
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

                PickupAnnounce.SetActive(false);
            }
        }

        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("IsAttacking", true);
        }
        else 
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    
}

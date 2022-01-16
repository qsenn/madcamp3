using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    player.GetComponent<Health>().DamagePlayer(20);
                }
            }
        }
    }

    void OnTriggerEnter (Collider collision)
    {
        if (collision.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerEixt (Collider collision)
    {
        if (collision.transform == player)
        {
            isPlayerInRange = false;
        }
    }
}

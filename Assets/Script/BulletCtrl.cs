using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // 총알의 공격력
    public int currentWeaponaDamage = 5;

    // 총알 발사 속도
    public float speed = 1000.0f;

    private Transform tr;
    private Health targetHealth;

    // Start is called before the first frame update
    void Start()
    {
        // 총알이 생성되자마자 Z축 방향으로 1000만큼의 힘을 받고 날아간다
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            targetHealth = collision.GetComponent<Health>();
            targetHealth.DamagePlayer(currentWeaponaDamage);
        }
    }
}

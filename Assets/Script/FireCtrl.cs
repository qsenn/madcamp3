using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    // 총알 프리팹
    public GameObject bullet;
    // 총알 발사좌표
    public Transform firePos;
    
    private bool RifleEnabled = false;

    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼 클릭시 Fire 메서드 호출
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fire();
        }
    }

    public void EnableRifle()
    {
        RifleEnabled = true;
    }

    public void DisableRifle()
    {
        RifleEnabled = false;
    }

    private void Fire()
    {
        // 총알 프리팹을 동적으로 생성
        if (RifleEnabled)
        {
            Instantiate(bullet, firePos.position, firePos.rotation);

            if (audioSource) audioSource.Play();
        }   
    }
}

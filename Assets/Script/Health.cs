using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;

    public int curHealth = 0;

    [SerializeField] LayerMask currentPlayer;

    // public event Action<float> OnHealthPctChanged = delegate {};

    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {  
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamagePlayer(10);
        }

        if (curHealth <= 0)
        {
            curHealth = 0;
            playerDied();
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        // float currentHealthPct = (float) currentHealth / (float) maxHealth;
        // OnHealthPctChanged(currentHealthPct);
       healthBar.SetHealth(curHealth);
    }

    public void playerDied()
    {
        if (gameObject.layer == 9)
        {
            LevelManager.instance.GameOver();
        }
        gameObject.SetActive(false);
    }
}

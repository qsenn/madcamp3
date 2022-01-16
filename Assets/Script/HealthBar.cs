using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Health playerHealth;
    public Gradient gradient;
    public Image fill;

    // [SerializeField] float updateSpeedSeconds = 0.5f;

/*
    private void Awake()
    {
        GetComponentInParent<Health>().OnHelathPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutino(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = fill.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elasped += Time.deltaTime;
        }
    }
*/

    void Start()
    {
        // playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        // healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;

        gradient.Evaluate(1f);
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;

        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        healthText.text = "Player Health : " + currentHealth;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            currentHealth--;

            if (currentHealth > 0)
            {
                anim.SetTrigger("isHit");
                healthText.text = "Player Health : " + currentHealth;
                return;
            }

            healthText.text = "";
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("isDeath");
    }

    private void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}

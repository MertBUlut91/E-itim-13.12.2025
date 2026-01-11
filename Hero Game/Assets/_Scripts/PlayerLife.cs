using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerMovement movement;

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private bool canTakeDamage = true;

    [SerializeField] private TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        healthText.text = "Player Health : " + currentHealth;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
        movement = GetComponent<PlayerMovement>();
        
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            movement.enabled = false;
        }

        //IfCharacterFall();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Traps") && canTakeDamage)
        {
            currentHealth--; 
            canTakeDamage = false;

            if (currentHealth > 0)
            {
                anim.SetTrigger("isHit");
                healthText.text = "Player Health : " + currentHealth;
                Invoke("SetCanTakeDamage", 0.2f);
                return;
            }

            healthText.text = "";
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FallCollider"))
        {
            StartRestartLevel();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("isDeath");
        anim.SetBool("isAlive", false);
    }

    private void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    private void StartRestartLevel()
    {
        Invoke("RestartLevel", 1f);
    }
    private void SetCanTakeDamage()
    {
        canTakeDamage = true;
    }
    
    private void IfCharacterFall()
    {
        if (transform.position.y < -20)
        {
            RestartLevel();
        }
    }
}

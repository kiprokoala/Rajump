using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    private float invicibility = 0.2f;
    public bool isInvicible = false;

    public SpriteRenderer graphics;
    public Lifebar lifebar;

    public AudioClip soundDeath;
    public AudioClip soundDamage;
    public AudioClip soundGainlife;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        lifebar.SetMaxHealth(currentHealth);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    takeDamage(5);
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    gainHealth(1);
        //}
    }

    public void takeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            lifebar.setHealth(currentHealth);
            if (currentHealth <= 0)
            {
                AudioManager.instance.PlayClip(soundDeath, transform.position);
                Death();
                return;
            }
            AudioManager.instance.PlayClip(soundDamage, transform.position);
            isInvicible = true;
            StartCoroutine(Invicibility());
            StartCoroutine(InvicibilityDelay());
        }
    }

    public void gainHealth(int heal)
    {
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            AudioManager.instance.PlayClip(soundGainlife, transform.position);
            currentHealth += heal;
        }
        lifebar.setHealth(currentHealth);
    }

    public IEnumerator Invicibility()
    {
        while (isInvicible)
        {
            graphics.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            yield return new WaitForSeconds(invicibility);
            graphics.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            yield return new WaitForSeconds(invicibility);
        }
    }

    public IEnumerator InvicibilityDelay()
    {
        yield return new WaitForSeconds(1f);
        isInvicible = false;
    }

    private void Death()
    {
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Death");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.onPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        lifebar.setHealth(currentHealth);
    }
}

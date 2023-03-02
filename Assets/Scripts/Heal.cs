using UnityEngine;

public class Heal : MonoBehaviour
{
    public int lifeGain;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth)
        {
            PlayerHealth.instance.gainHealth(lifeGain);
            Destroy(gameObject);
        }
    }
}

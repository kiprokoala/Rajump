using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange = false;
    private PlayerMovement playerMovement;
    public BoxCollider2D top_collider;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.3f)
        {
            playerMovement.isClimbing = false;
            top_collider.isTrigger = false;
            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.DownArrow) || isInRange && Input.GetAxis("Vertical") > 0.1f)
        {
            playerMovement.isClimbing = true;
            top_collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            top_collider.isTrigger = false;
        }
    }
}

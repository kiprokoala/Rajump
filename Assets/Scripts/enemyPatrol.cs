using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class enemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision;

    public SpriteRenderer spriteRenderer;

    private Transform target;
    private int destPoint =0;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
            //La ligne au-dessus permet de flip les colliders en même temps (trick seulement possible en 2d)
            //spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.takeDamage(damageOnCollision);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Transform attackTarget;
    private Rigidbody2D rb2D;

    public float Speed;
    private Vector2 direction;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        attackTarget = GameManager.Instance.monster;
    }

    private void FixedUpdate()
    {
        direction = DirectionToTarget();
        rb2D.velocity = direction * Speed;
    }

    private Vector2 DirectionToTarget()
    {
        return ((Vector2)attackTarget.position - rb2D.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Debug.Log("Hit");
            GameManager.Instance.pool.Release(gameObject.tag, gameObject);
        }
    }
}
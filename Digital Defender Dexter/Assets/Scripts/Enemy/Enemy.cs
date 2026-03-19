using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float health;
    [SerializeField] private GameObject destroyEffect;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerController.Instance.gameObject.activeSelf)
        {
            //control facing player left and right
            if (PlayerController.Instance.transform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
            //control facing the player up and down
            if (PlayerController.Instance.transform.position.y > transform.position.y)
            {
                spriteRenderer.flipY = true;
            }
            else
            {
                spriteRenderer.flipY = false;
            }

            //move at player
            direction = (PlayerController.Instance.transform.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.TakeDamage(damage);
            
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, transform.rotation);
        }
    }
}

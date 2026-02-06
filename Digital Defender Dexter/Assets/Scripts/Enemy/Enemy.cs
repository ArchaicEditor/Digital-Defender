using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;


    // Update is called once per frame
    void FixedUpdate()
    {

        //control facing player left and right
        if (PlayerController.Instance.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }else
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
        rb.linearVelocity = new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);
    }
}

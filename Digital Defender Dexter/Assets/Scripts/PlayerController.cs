using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    public Vector3 playerMoveDirection;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        playerMoveDirection = new Vector2(inputX, inputY).normalized;


    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (playerMoveDirection.x * moveSpeed * Time.deltaTime, playerMoveDirection.y * moveSpeed * Time.deltaTime);
        

    }



}

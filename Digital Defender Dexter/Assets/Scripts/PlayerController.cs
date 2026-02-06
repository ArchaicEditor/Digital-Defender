using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    public Vector3 playerMoveDirection;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    
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

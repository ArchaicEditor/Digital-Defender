using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 6f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;
    }



}

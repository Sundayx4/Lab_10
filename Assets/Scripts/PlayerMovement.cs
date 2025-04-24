using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    float move;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isjumping;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //walk
        move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        //jump
        if (Input.GetButtonDown("Jump") && !isjumping) 
        {
            rb2D.AddForce(new Vector2(rb2D.linearVelocity.x, jumpForce));
            Debug.Log("Jump!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            isjumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {  
            isjumping = true; 
        }
    }

}

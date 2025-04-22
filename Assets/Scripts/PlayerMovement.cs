using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rd2D;

    Vector2 moveInput;

    float move;
    [SerializeField] float speed;

    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;

    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>(); 
    }
    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rd2D.AddForce(moveInput * speed);


        //move = Input.GetAxis("Horizontal");
        //rd2D.linearVelocity = new Vector2(move * speed, rd2D.linearVelocity.y);

        if (Input.GetButtonDown("Jump")  && !isJumping)
        {
            rd2D.AddForce(new Vector2(rd2D.linearVelocity.x, jumpForce));
            Debug.Log("Jump!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
        
}

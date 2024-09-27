using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;
    public float jumpForce = 400f;
    public LayerMask groundMask;

    private void FixedUpdate()
    {
        if (!alive) return;
        
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }
    public void Die()
    {
        alive = false;
        //restart game
        Invoke("Restart", 2);
    }
    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void jump ()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }
}

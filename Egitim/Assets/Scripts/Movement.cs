using UnityEngine;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;

    [SerializeField] private float radius;
    [SerializeField] private Transform feetPos;
    [SerializeField] LayerMask layerMask;

    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravityScale;

    [SerializeField] SpriteRenderer playerRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizantalMove = Input.GetAxis("Horizontal"); 

        rb.linearVelocity = new Vector2(horizantalMove * moveSpeed, rb.linearVelocityY);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rb.linearVelocityY >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.linearVelocityY <= 0)
        {
            rb.gravityScale = fallGravityScale;
        }

        if (horizantalMove > 0)
        {
            playerRenderer.flipX = false;
        }
        else if(horizantalMove  < 0)
        {
            playerRenderer.flipX = true;
        }


    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(feetPos.position, radius);
    }
}

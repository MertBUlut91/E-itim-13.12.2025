using UnityEngine;

public class BallObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isActive)
        {
            DropBall();
        }
    }

    public void DropBall()
    {
        rb.gravityScale = 1;
    }

    public void SetBool(bool isTrue)
    {
        isActive = isTrue;
    }
}

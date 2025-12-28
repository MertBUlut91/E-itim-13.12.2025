using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public bool isActive;
    [SerializeField] private int moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isActive) {

            MoveArrow();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hasar aldý.");
        }
    }

    private void MoveArrow()
    {
        rb.linearVelocity = new Vector2(1f * moveSpeed, 0f);
    }


}

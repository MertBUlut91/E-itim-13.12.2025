using UnityEngine;

public class BallTrapper : MonoBehaviour
{
    [SerializeField] private BallObject ballObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ballObject.SetBool(true);
        }
    }
}

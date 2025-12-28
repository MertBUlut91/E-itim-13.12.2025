using UnityEngine;
using DG.Tweening;

public class Collectible : MonoBehaviour
{

    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(0, 1 *rotateSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Puan Aldý");
            gameObject.SetActive(false);
        }
    }
}

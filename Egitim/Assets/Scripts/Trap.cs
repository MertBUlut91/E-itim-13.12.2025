using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Enemy enemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player dokundu");

            enemy.gameObject.SetActive(true);
            enemy.isActive = true;
        }
    }
}

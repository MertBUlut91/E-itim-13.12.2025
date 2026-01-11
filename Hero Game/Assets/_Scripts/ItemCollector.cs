using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int fruits;
    [SerializeField] private TextMeshProUGUI fruitText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            Destroy(collision.gameObject);
            fruits++;
            fruitText.text = "Meyve : " + fruits;
            Debug.Log("Elma Alýndý");
        }
    }
}



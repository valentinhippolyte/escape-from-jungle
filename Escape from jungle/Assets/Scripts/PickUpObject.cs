using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Permet de ramasser des objets et les ajouter à l'inventaire 
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(1);
            //Supprime l'objet rammassé de la scène 
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    //Permet la destruction de l'ennemi 
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //On vérifie que la collision avec l'ennemy est bien faite avec le joueur 
        if (collision.CompareTag("Player"))
        {
            //Si c'est le cas, on détruit l'ennemi
            Destroy(objectToDestroy);
        }
    }
}

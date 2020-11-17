using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    // Gestion de l'inventaire 

    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        // Permet de vérifier qu'un seul inventaire est actif
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this;
    }
    // ajoute des totems 
    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

}

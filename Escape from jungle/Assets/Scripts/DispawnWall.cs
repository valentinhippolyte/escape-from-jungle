using UnityEngine;
using UnityEngine.Tilemaps;

public class DispawnWall : MonoBehaviour
    // Permet d'accéder aux portes quand les murs disparaissent
{
    public TilemapRenderer tr;
    public TilemapCollider2D tilemapCollider;
    private Inventory inventory;
    public int nbTotems;

    void Update()
    {
        //lorsque qu'on a assez de totems, le mur empêchant l'accès au niveau suivant disparait
        if (Inventory.instance.coinsCount >= nbTotems)
        {
            tr.enabled = false;
            tilemapCollider.enabled = false;
        }
    }



}
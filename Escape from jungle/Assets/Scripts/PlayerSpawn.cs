using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Awake()
    {
        //Place le joueur à l'endroit indique par l'empty PlayerSpawn dans les scènes 
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}

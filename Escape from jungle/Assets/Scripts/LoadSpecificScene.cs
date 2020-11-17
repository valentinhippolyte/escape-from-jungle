using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    //Permet de charger la scène souhaitée (système utilisé pour passer d'un niveau à un autre) 
    //Renseigner la scène voulue (ici un nom d'où String) 
    public string sceneName;
    //permet de créer un fondu pour les transitions 
    public Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    // Si le joueur rentre en contact avec l'objet 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}

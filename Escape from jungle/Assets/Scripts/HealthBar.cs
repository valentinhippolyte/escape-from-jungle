using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    //Gestion de la barre de vie 
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        //Permet le remplissage de la barre 
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

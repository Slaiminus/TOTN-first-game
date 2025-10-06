using UnityEngine;
using UnityEngine.UI;

public class health_display : MonoBehaviour
{
    [SerializeField] private PlayerLogic hp;
    [SerializeField] private Slider slider;

    void Update()
    {
        slider.value = hp.health / (float) hp.maxhealth;
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_year_objectif : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI moneyGoal;

    void Start()
    {
        
    }

    public void SetSlider(float value)
    {
        slider.value = value;
    }
}

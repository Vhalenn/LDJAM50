using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UI_year_objectif : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI moneyGoal;
    [SerializeField] TextMeshProUGUI moneyEarned;
    [SerializeField] TextMeshProUGUI bonusText;
    [SerializeField] TextMeshProUGUI bankText;
    [SerializeField] float progress = 0;

    void Start()
    {
        
    }

    public void SetSlider(float value, float money)
    {
        progress = value;
        slider.value = value;
        if(moneyEarned) moneyEarned.text = Constant.DisplayBigNumber(money) + " $";

        if (value <= 1)
        {
            bonusText.enabled = false;
        }
        else
        {
            bonusText.enabled = true;
            int bonus = Mathf.FloorToInt((value - 1.0f) * 100.0f);
            bonusText.text = "+" + bonus.ToString() + "%";
        }
    }

    public void SetGoal(float goal)
    {
        string txt = Constant.DisplayBigNumber(goal);
        moneyGoal.text = txt + " $";
    }

    public void SetBank(float bank)
    {
        bankText.text = "Bank\n" + Constant.DisplayBigNumber(bank) + " $";
    }
}

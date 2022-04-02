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
        if(moneyEarned) moneyEarned.text = ConvertBigNumberText(money) + " $";

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
        string txt = ConvertBigNumberText(goal);
        moneyGoal.text = txt + " $";
    }

    public void SetBank(float bank)
    {
        bankText.text = "Bank\n" + ConvertBigNumberText(bank) + " $";
    }

    string ConvertBigNumberText(float n)
    {
        string txt = string.Empty;
        if (n >= 1000000000) txt = (n / 1000000000).ToString("F1") + "b";
        else if (n >= 1000000) txt = (n / 1000000).ToString("F1") + "m";
        else if (n >= 1000) txt = (n / 1000).ToString("F1") + "k";
        else txt = n.ToString("F0");

        return txt;
    }
}

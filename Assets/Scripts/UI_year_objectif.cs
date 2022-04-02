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

    string ConvertBigNumberText(float n)
    {
        //string txt = string.Format("{0:0}", n);

        /*
        List<char> num = new List<char>();
        int index = 0;

        for (int i = txt.Length - 1; i >= 0; i--)
        {
            num.Add(txt[i]);
            index++;
            if (index % 3 == 0 
                && index < txt.Length) num.Add('.');
        }

        num.Reverse();
        */

        string txt = string.Empty;
        if (n >= 1000000000) txt = (n / 1000000000).ToString("F1") + "b";
        else if (n >= 1000000) txt = (n / 1000000).ToString("F1") + "m";
        else if (n >= 1000) txt = (n / 1000).ToString("F1") + "k";

        return txt;
    }
}

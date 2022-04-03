using UnityEngine;
using TMPro;

public class UI_Interaction : MonoBehaviour
{
    [SerializeField] MoneyManager money;
    [SerializeField] TowerManager tower;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        if (money) SetMoneyText();
        else if (tower) SetFloorTxt();
    }

    public void ChangeSalaries(bool state)
    {
        money.salariy *= state ? 1.05f : 0.95f;
        SetMoneyText();
    }

    void SetMoneyText()
    {
        text.text = Constant.DisplayBigNumber(money.salariy) + " $ gross";
    }

    public void ChangeFloorDensity(bool state)
    {
        tower.floorDensity += state ? 10 : -10;
        tower.UpdateStats();
        SetFloorTxt();
    }

    void SetFloorTxt()
    {
        text.text = tower.floorDensity.ToString() + " per floor";
    }
}

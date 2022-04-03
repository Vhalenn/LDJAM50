using UnityEngine;
using TMPro;

public class UI_buildingCost : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] MoneyManager money;

    void OnEnable()
    {
        Refresh();
    }
    public void Refresh()
    {
        txt.text = Constant.DisplayBigNumber(money.floorCost) + " $";
    }
}

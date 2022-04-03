using UnityEngine;
using TMPro;

public class UI_Recap : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI employees;
    [SerializeField] TextMeshProUGUI salaries;
    [SerializeField] TextMeshProUGUI gain;

    [Header("Colors")]
    [SerializeField] Color good;
    [SerializeField] Color bad;

    public void UpdateSalariesGain(float salaries, float gain)
    {
        this.salaries.text = "Salaries : " + Constant.DisplayBigNumber(salaries) + " $";
        this.gain.text = "Monthly gain\n" + Constant.DisplayBigNumber(gain) + " $";
        if (gain > 0) this.gain.color = good;
        else this.gain.color = bad;
    }
}

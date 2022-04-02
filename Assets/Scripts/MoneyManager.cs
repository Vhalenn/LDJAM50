using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] UI_Canvas uiCanvas;
    UI_year_objectif yearObjectif;

    [SerializeField] TowerManager tower;
    public float moneyBank;
    public float moneyEarned;
    public float moneyGoal = 5000000;
    [SerializeField][Range(0,1)] float goalProgress;

    [Header("Employees Stats")]
    public float moneyProduced = 2200;
    public float salariy = 2000;

    [Header("Tower Stats")]
    public float floorCost = 100000;

    void Start()
    {
        moneyBank = moneyGoal * 0.1f;
        if (uiCanvas) yearObjectif = uiCanvas.uiObjectif;

        UpgateUI();
    }

    public void MonthEnd()
    {
        int employeeCount = tower.employeeCount;
        moneyEarned += employeeCount * moneyProduced; // Earned money
        moneyEarned -= employeeCount * salariy; // Salairies

        goalProgress = moneyEarned / moneyGoal;

        if (yearObjectif) yearObjectif.SetSlider(goalProgress, moneyEarned);
    }

    public void DecadeEnd()
    {
        moneyBank = moneyEarned * 0.2f;
        float moneyToShareHolders = moneyEarned * 0.8f;
        Debug.Log("Gaved " + string.Format("{0:0}",moneyToShareHolders) + " $ to the sshareholders");
        moneyEarned = 0;
        //moneyEarned -= moneyGoal;
        moneyGoal *= 1.5f;

        UpgateUI();
    }

    void UpgateUI()
    {
        if (yearObjectif)
        {
            yearObjectif.SetGoal(moneyGoal);
            yearObjectif.SetBank(moneyBank);
            yearObjectif.SetSlider(goalProgress, moneyEarned);
        }
    }

    public bool NewFloorBuilt()
    {
        if (moneyBank >= floorCost)
        {
            moneyBank -= floorCost;
        }
        else if (moneyEarned >= floorCost)
        {
            moneyEarned -= (floorCost - moneyBank);
            moneyBank = 0;
        }
        else return false;

        floorCost *= 1.1f;
        UpgateUI();
        return true;
    }
}

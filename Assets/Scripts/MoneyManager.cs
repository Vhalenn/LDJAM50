using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] UI_Canvas uiCanvas;
    [SerializeField] UI_Recap uiRecap;
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

    // Storage
    float totalSalaries;
    float totalProduced;
    float monthGain;

    void Start()
    {
        moneyBank = moneyGoal * 0.1f;
        if (uiCanvas) yearObjectif = uiCanvas.uiObjectif;

        UpgateUI();
    }

    public void MonthEnd()
    {
        int employeeCount = tower.employeeCount;
        totalSalaries = employeeCount * salariy; // Pay of the workers
        totalProduced = employeeCount * moneyProduced; // Money earned by the company
        monthGain = totalProduced - totalSalaries;

        moneyEarned += monthGain;

        goalProgress = moneyEarned / moneyGoal;

        UpgateUI();
    }

    public void YearEnd(int year)
    {
        //Debug.Log("End of the year " + year);
        moneyProduced *= Constant.inflation;
    }

    public void DecadeEnd()
    {
        float shareHolders = Constant.partToTheShareHolders;
        moneyBank = moneyEarned * (1.0f - shareHolders);
        float moneyToShareHolders = moneyEarned * shareHolders;

        string toTheShareholders = Constant.DisplayBigNumber(moneyToShareHolders);
        string message = "Terry, we are very proud of you !\n " +
            "Our shareholders earned " + toTheShareholders + " $ !\n\n " +
            "Continue like this !";
        //Debug.Log("Gaved " + toTheShareholders + " $ to the shareholders");

        UI_Bubble.ShowText(message);
        moneyEarned = 0;

        moneyGoal *= Constant.moneyGoalMultiplier;

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

        if(uiRecap)
        {
            uiRecap.UpdateSalariesGain(totalSalaries, monthGain);
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

        floorCost *= Constant.newFloorCost;
        UpgateUI();
        return true;
    }
}

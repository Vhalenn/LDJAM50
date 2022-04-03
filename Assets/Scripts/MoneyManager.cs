using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] UI_Canvas uiCanvas;
    [SerializeField] UI_Recap uiRecap;
    [SerializeField] GameManager gameManager;
    [SerializeField] AngerManager angerManager;
    UI_year_objectif yearObjectif;

    [SerializeField] TowerManager tower;
    public float moneyBank;
    public float moneyEarned;
    public float moneyGoal = 5000000;
    [SerializeField][Range(0,1)] float goalProgress;
    public int failedGoals;

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
        angerManager.Relax();

        moneyProduced *= Constant.inflation;
    }

    public void DecadeEnd()
    {
        float shareHolders = Constant.partToTheShareHolders;
        moneyBank = moneyEarned * (1.0f - shareHolders);
        float moneyToShareHolders = moneyEarned * shareHolders;
        string toTheShareholders = Constant.DisplayBigNumber(moneyToShareHolders);

        bool sucess = goalProgress >= 0.999f;
        string message = string.Empty;


        if (sucess)
        {
            message = "Terry, we are very proud of you !\n " +
                "Our shareholders earned " + toTheShareholders + " $ !\n\n " +
                "Continue like this !";
        }
        else
        {
            /*
            message = "Terry, we are note proud of you ! You failed reaching your financial goal ! \n" +
                "Don't do that again or it may be the last one !";
            */
            failedGoals++;

            if (failedGoals == 1) gameManager.Warning();
            else if (failedGoals > 3) gameManager.GameOver(); 
        }

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

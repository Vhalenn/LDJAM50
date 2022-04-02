using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] UI_Canvas uiCanvas;
    UI_year_objectif yearObjectif;

    [SerializeField] TowerManager tower;
    [SerializeField] float moneyEarned;
    [SerializeField] float moneyGoal = 5000000;
    [SerializeField][Range(0,1)] float goalProgress;

    [Header("Employees Stats")]
    public float moneyProduced = 2200;
    public float salariy = 2000;

    [Header("Tower Stats")]
    public float floorCost = 100000;

    void Start()
    {
        if (uiCanvas) yearObjectif = uiCanvas.uiObjectif;
    }

    void Update()
    {
        
    }

    public void MonthEnd()
    {
        int employeeCount = tower.employeeCount;
        moneyEarned += employeeCount * moneyProduced; // Earned money
        moneyEarned -= employeeCount * salariy; // Salairies

        goalProgress = moneyEarned / moneyGoal;

        if (yearObjectif) yearObjectif.SetSlider(goalProgress);
    }

    public void DecadeEnd()
    {
        moneyEarned = 0;
        //moneyEarned -= moneyGoal;
        moneyGoal *= 1.5f;

        if (yearObjectif) yearObjectif.SetSlider(goalProgress);
    }

    public void NewFloorBuilt()
    {
        moneyEarned -= floorCost;
        floorCost *= 1.1f;
    }
}

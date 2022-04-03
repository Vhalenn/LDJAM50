using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] UI_Canvas uiCanvas;
    [SerializeField] MoneyManager moneyManager;
    UI_yearProgress uiYearProgress;

    [Header("Values")]
    public float yearProgress;
    public float decadeProgress;

    public int d, m, y, decade;
    private int oldM, oldY, oldDecade;

    [Header("Variables")]
    [SerializeField] int startYear;
    [SerializeField] float timeSpeed;

    void Start()
    {
        if(uiCanvas) uiYearProgress = uiCanvas.uiTime;
    }

    void Update()
    {
        yearProgress += Time.deltaTime * timeSpeed;

        int year = Mathf.FloorToInt(yearProgress);
        y = startYear + year; 
        m = 1 + Mathf.FloorToInt((yearProgress-year) * 12.0f);

        decadeProgress = Mathf.Repeat(yearProgress, 10.0f) / 10.0f;
        decade = Mathf.FloorToInt(yearProgress / 10.0f);

        if (uiYearProgress)
        {
            uiYearProgress.progress = decadeProgress;
            uiYearProgress.year = y;
        }

        // IF CHANGES
        if(m != oldM)
        {
            moneyManager.MonthEnd();
            oldM = m;
        }

        if (y != oldY)
        {
            moneyManager.YearEnd(oldY);
            oldY = y;
        }


        if(decade != oldDecade)
        {
            Debug.Log("NEW DECADE !!! We are now in " + y);
            moneyManager.DecadeEnd();
            oldDecade = decade;
        }
    }
}

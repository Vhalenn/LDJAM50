using UnityEngine;

public class AngerManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameManager gameManager;
    [SerializeField] TimeManager timeManager;
    [SerializeField] TowerManager tower;
    [SerializeField] MoneyManager money;
    [SerializeField] UI_Workers uiWorkers;

    [Header("Variables")]
    [Range(0,1)] public float progress; 
    public float angriness = 0.1f;
    [SerializeField] float densityModifier;
    [SerializeField] float moneyModifier;
    [SerializeField] float angerProgress;


    void Update()
    {
        // BASE
        angerProgress = Time.deltaTime * angriness * timeManager.timeSpeed;

        densityModifier = ( (90 * 1.3f) - tower.floorDensity) * 0.007f;
        angerProgress *= densityModifier;

        moneyModifier = (((money.salariy * 2f) - money.moneyProduced ) * 0.001f);
        angerProgress *= moneyModifier;

        progress += angerProgress;
        progress = Mathf.Max(0, progress);

        uiWorkers.SetSlider(progress);

        if (progress > 1) gameManager.GameOver();
    }

    public void Relax()
    {
        progress *= 0.99f;
    }
}

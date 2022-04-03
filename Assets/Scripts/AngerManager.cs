using UnityEngine;

public class AngerManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameManager gameManager;
    [SerializeField] TimeManager timeManager;
    [SerializeField] TowerManager tower;
    [SerializeField] UI_Workers uiWorkers;

    [Header("Variables")]
    [Range(0,1)] public float progress; 
    public float angriness = 0.1f;
    [SerializeField] float densityModifier;


    void Update()
    {
        float angerProgress = Time.deltaTime * angriness * timeManager.timeSpeed;
        densityModifier = 1 + ((tower.floorDensity - 90) * 0.05f);
        angerProgress *= Mathf.Max(densityModifier, 0.9f);

        progress += angerProgress;

        uiWorkers.SetSlider(progress);

        if (progress > 1) gameManager.GameOver();
    }

    public void Relax()
    {
        progress *= 0.99f;
    }
}

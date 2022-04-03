using UnityEngine;

public class AngerManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TowerManager tower;
    [SerializeField] UI_Workers uiWorkers;
    [SerializeField] int employeeCount;

    [Header("Variables")]
    [Range(0,1)] public float progress; 
    public float anger;
    public float angriness = 0.1f;


    void Start()
    {
        
    }

    void Update()
    {
        employeeCount = tower.employeeCount;
        anger += Time.deltaTime * angriness * employeeCount;

        progress = anger / (float)employeeCount;

        uiWorkers.SetSlider(progress);

    }
}

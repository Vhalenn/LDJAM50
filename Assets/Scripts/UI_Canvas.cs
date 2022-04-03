using UnityEngine;

public class UI_Canvas : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    [Header("World")]
    public TowerManager towerManager;

    [Header("Canvas")]
    public UI_yearProgress uiTime;
    public UI_year_objectif uiObjectif;
    public UI_Workers uiWorkers;


    public void BuildNewFloor()
    {
        towerManager.BuildNewFloor();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F10))
        {
            canvas.enabled = !canvas.enabled;
        }
    }
}

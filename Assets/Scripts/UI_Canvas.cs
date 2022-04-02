using UnityEngine;

public class UI_Canvas : MonoBehaviour
{
    [Header("World")]
    public TowerManager towerManager;

    [Header("Canvas")]
    public UI_yearProgress uiTime;
    public UI_year_objectif uiObjectif;


    public void BuildNewFloor()
    {
        towerManager.BuildNewFloor();
    }
}

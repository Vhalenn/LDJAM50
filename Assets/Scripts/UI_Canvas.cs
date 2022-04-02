using UnityEngine;

public class UI_Canvas : MonoBehaviour
{
    public TowerManager towerManager;

    public void BuildNewFloor()
    {
        towerManager.BuildNewFloor();
    }
}

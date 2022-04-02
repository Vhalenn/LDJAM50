using UnityEngine;
using DG.Tweening;

public class TowerManager : MonoBehaviour
{
    public float floorHeight = 5;
    public int floorsCount = 0;
    public int employeeCount = 0;

    [Header("Prefabs")]
    [SerializeField] Floor floorPrefab;
    [SerializeField] Floor roofPrefab;

    [Header("Elements")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] Transform floorParent;
    [SerializeField] Transform roofParent;

    [Header("Camera")]
    [SerializeField] Transform _cameraTarget;

    [Header("Storage")]
    [SerializeField] UI_Canvas uiCanvas;
    UI_Workers uiWorkers;
    [SerializeField] Floor[] floorArray;

    void Start()
    {
        if (uiCanvas) uiWorkers = uiCanvas.uiWorkers;

        ActualizeFloorCount();
        SetCameraHeight(floorsCount - 1);
    }

    public void BuildNewFloor()
    {

        bool validation = moneyManager.NewFloorBuilt();
        if(!validation) // NOT ENOUGH MONEY
        {
            return;
        }

        Floor newFloor = Instantiate(floorPrefab, floorParent);

        int floor = newFloor.transform.GetSiblingIndex();
        float height = floorHeight * floor;
        newFloor.transform.position = new Vector3(0, height, 0);
        newFloor.transform.rotation = Quaternion.Euler(0, Mathf.RoundToInt(Random.value * 4) * 90, 0);
        newFloor.transform.localScale = Vector3.one * 0.01f;
        newFloor.transform.DOScale(Vector3.one, 0.3f);

        SetCameraHeight(floor);

        roofParent.DOLocalMoveY(height, 0.3f);
        ActualizeFloorCount();

    }

    void ActualizeFloorCount()
    {
        floorsCount = floorParent.childCount;
        employeeCount = 0;

        floorArray = new Floor[floorsCount];
        for (int i = 0; i < floorsCount; i++)
        {
            Transform tr = floorParent.GetChild(i);

            if (!tr) continue;
            floorArray[i] = tr.GetComponent<Floor>();

            if (!floorArray[i]) continue;
            employeeCount += floorArray[i].numberOfEmployees;
        }

        if (uiWorkers) uiWorkers.SetEmployeeCount(employeeCount);
    }

    void SetCameraHeight(int floor)
    {
        if (!_cameraTarget) return;
        
        Vector3 pos = _cameraTarget.transform.position;
        pos.y = floorHeight * floor;
        _cameraTarget.transform.position = pos;
        
    }
}

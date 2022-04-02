using UnityEngine;

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
    [SerializeField] Floor[] floorArray;

    void Start()
    {
        ActualizeFloorCount();
        SetCameraHeight(floorsCount - 1);
    }

    public void BuildNewFloor()
    {
        Floor newFloor = Instantiate(floorPrefab, floorParent);

        int floor = newFloor.transform.GetSiblingIndex();
        float height = floorHeight * floor;
        newFloor.transform.position = new Vector3(0, height, 0);

        SetCameraHeight(floor);

        roofParent.transform.localPosition = new Vector3(0, height, 0); 
        ActualizeFloorCount();

        moneyManager.NewFloorBuilt();
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
    }

    void SetCameraHeight(int floor)
    {
        if (!_cameraTarget) return;
        
        Vector3 pos = _cameraTarget.transform.position;
        pos.y = floorHeight * floor;
        _cameraTarget.transform.position = pos;
        
    }
}

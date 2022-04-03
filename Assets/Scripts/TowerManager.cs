using UnityEngine;
using DG.Tweening;

public class TowerManager : MonoBehaviour
{
    public float floorHeight = 5;
    public int floorsCount = 0;
    public int workersCount = 0;
    public int employeeCount = 0;
    public int floorDensity = 90;

    [Header("Prefabs")]
    [SerializeField] Floor floorPrefab;
    [SerializeField] Floor roofPrefab;

    [Header("Elements")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] Transform floorParent;
    [SerializeField] Transform roofParent;
    [SerializeField] GameObject towerTop;

    [Header("Camera")]
    [SerializeField] Cam _cam;

    [Header("Audio")]
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

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
            UI_Bubble.ShowText("The company don't have enought money to do that Terry !");
            return;
        }

        source.pitch = Random.Range(0.5f, 1.5f);
        source.PlayOneShot(clip);
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

    public void UpdateStats()
    {
        employeeCount = floorDensity * floorsCount;
        if (uiWorkers) uiWorkers.SetEmployeeCount(employeeCount);
    }

    void ActualizeFloorCount()
    {
        floorsCount = floorParent.childCount;
        employeeCount = 0;

        towerTop.SetActive(floorsCount > 12);

        floorArray = new Floor[floorsCount];
        for (int i = 0; i < floorsCount; i++)
        {
            Transform tr = floorParent.GetChild(i);

            if (!tr) continue;
            floorArray[i] = tr.GetComponent<Floor>();

            /*
            if (!floorArray[i]) continue;
            employeeCount += floorArray[i].numberOfEmployees;
            */
        }

        UpdateStats();
    }

    void SetCameraHeight(int floor)
    {
        if (!_cam) return;

        _cam.SetCameraHeight(floorHeight * floor, false);
    }
}

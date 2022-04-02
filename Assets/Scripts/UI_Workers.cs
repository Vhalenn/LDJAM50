using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Workers : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI numOfEmployees;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetEmployeeCount(int count)
    {
        string word = count > 0 ? "employees" : "employee";
        numOfEmployees.text = count.ToString() + "\n" + word;
    }
}

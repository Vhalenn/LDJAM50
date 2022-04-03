using UnityEngine;

public class Floor : MonoBehaviour
{
    public int numberOfEmployees = 30;
    public int maxOfEmployees = 90;
    public float baseAngriness = 1f;

    public void Start()
    {
        numberOfEmployees = maxOfEmployees;
    }

}

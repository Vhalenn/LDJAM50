using UnityEngine;
using TMPro;

public class UI_Bubble : MonoBehaviour
{
    public static UI_Bubble instance;
    [SerializeField] GameObject parent;
    [SerializeField] TextMeshProUGUI txt;

    void Start()
    {
        UI_Bubble.instance = this;
    }

    void Update()
    {
        
    }

    public void Clicked()
    {
        parent.SetActive(false);
    }

    void WriteText(string toWrite)
    {
        txt.text = toWrite;
    }

    public static void ShowText(string toWrite)
    {
        instance.WriteText(toWrite);
    }
}

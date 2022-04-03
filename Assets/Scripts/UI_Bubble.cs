using UnityEngine;
using DG.Tweening;
using TMPro;

public class UI_Bubble : MonoBehaviour
{
    public static UI_Bubble instance;
    [SerializeField] GameObject parent;
    [SerializeField] TextMeshProUGUI txt;

    string lastWord;
    float time;

    void Start()
    {
        UI_Bubble.instance = this;
        Clicked();
    }

    void Update()
    {
        if(!string.IsNullOrEmpty(lastWord))
        {
            time += Time.deltaTime;
            if(time > 5)
            {
                lastWord = string.Empty;
                time = 0;
            }
        }

        if (!parent.activeInHierarchy) return;
    }

    public void Clicked()
    {
        parent.SetActive(false);
    }

    void WriteText(string toWrite)
    {
        if (toWrite == lastWord) return;

        parent.SetActive(true);
        Transform tr = transform;
        tr.localScale = Vector3.one * 0.001f;
        tr.DOScale(Vector3.one, 0.15f);
        tr.localRotation = Quaternion.Euler(0, 0, -5);
        tr.DOPunchRotation(Vector3.forward * 50, 0.2f);

        txt.text = toWrite;
        lastWord = toWrite;
        time = 0;
    }

    public static void ShowText(string toWrite)
    {
        instance.WriteText(toWrite);
    }
}

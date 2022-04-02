using UnityEngine;
using TMPro;

public class UI_yearProgress : MonoBehaviour
{
    [SerializeField] RectTransform rTransform;
    [SerializeField] TextMeshProUGUI yearText;
    [SerializeField] RectTransform redZone;

    [Header("Public")]
    [Range(0,1)] public float progress = 0;
    public int year;

    // STORAGE
    RectTransform parent;
    Vector2 parentSize;

    void Start()
    {
        parent = transform.parent.GetComponent<RectTransform>();
        if (!parent) return;

        parentSize = parent.sizeDelta;
    }

    void Update()
    {
        float sizeX = progress * parentSize.x;
        rTransform.anchoredPosition = new Vector2( sizeX ,0);
        yearText.text = year.ToString();

        redZone.sizeDelta = new Vector2(sizeX , redZone.sizeDelta.y);
        redZone.anchoredPosition = new Vector2(redZone.sizeDelta.x * 0.5f, 0);

    }


}

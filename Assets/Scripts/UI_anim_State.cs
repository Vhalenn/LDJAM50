using UnityEngine;
using DG.Tweening;

public class UI_anim_State : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    public Vector2 actualPos;

    [Header("Transition")]
    public bool state;
    [SerializeField] Vector2 posA = Vector2.zero, posB = Vector2.zero;

    [Header("Animation")]
    [SerializeField] float time = 0.3f;
    [SerializeField] float overshoot = 0.3f;
    [SerializeField] Ease animType = DG.Tweening.Ease.InOutCirc;

    void Start()
    {
        SetState();
    }

    void Update()
    {
        actualPos = rect.anchoredPosition;
    }

    public void ChangeState()
    {
        state = !state;
        SetState();
    }

    public void SetState(bool state)
    {
        if (state == this.state) return;
        this.state = state;
        SetState();
    }

    void SetState()
    {
        if (!Application.isPlaying) // || Time.timeSinceLevelLoad < 1f
        {
            if (state) rect.anchoredPosition = posA;
            else rect.anchoredPosition = posB;
        }
        else
        {
            DOTween.defaultEaseOvershootOrAmplitude = overshoot;

            if (state) rect.DOAnchorPos(posA, time).SetEase(animType);
            else rect.DOAnchorPos(posB, time).SetEase(animType);
        }
    }
}

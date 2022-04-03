using UnityEngine;

public class UI_Help : MonoBehaviour
{
    [SerializeField] Canvas[] canvas;

    private void Start()
    {
        SetState(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ShowHide();
        }
    }
    public void ShowHide()
    {
        if (canvas.Length < 1) return;

        SetState(!canvas[0].enabled);
    }

    public void SetState(bool state)
    {
        if (canvas.Length < 1) return;

        Time.timeScale = state ? 0 : 1;

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = state;
        }
    }
}

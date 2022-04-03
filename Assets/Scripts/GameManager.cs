using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool startWithMenu;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas menuCanvas;
    [SerializeField] UI_Help uiHelp;

    void Start()
    {
        Application.targetFrameRate = 60;

        if(!Application.isEditor || startWithMenu)
        {
            SetMenuState(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeMenuState();
        }
    }

    void ChangeMenuState()
    {
        SetMenuState(!menuCanvas.enabled);
    }

    public void SetMenuState(bool state)
    {
        menuCanvas.enabled = state;
        gameCanvas.enabled = !state;

        Time.timeScale = state ? 0 : 1;
    }

    public void StartWithTutorial()
    {
        SetMenuState(false);
        uiHelp.SetState(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
        #else
            Application.Quit();
        #endif
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool startWithMenu;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas menuCanvas;
    [SerializeField] UI_Help uiHelp;

    [Header("Game Over")]
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] GameObject warningWindow;

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
        if(!state)
        {
            gameOverWindow.SetActive(false);
            warningWindow.SetActive(false);
        }

        gameCanvas.enabled = !state;

        Time.timeScale = state ? 0 : 1;
    }

    public void StartWithTutorial()
    {
        SetMenuState(false);
        uiHelp.SetState(true);
    }

    public void GameOver()
    {
        gameOverWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Warning()
    {
        warningWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            //Application.OpenURL(webplayerQuitURL);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        #else
            Application.Quit();
        #endif
    }
}

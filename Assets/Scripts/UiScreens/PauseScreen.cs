using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : UiScreen
{
    override public void Show(UiScreen caller = null)
    {
        base.Show(caller);
        Time.timeScale = 0;
    }

    public void OnResumeButtonClick()
    {
        GameManager.Instance.GameScreen.Show(this);
    }

    public void OnGotoStartScreenButtonClick()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}

using UnityEngine;

public class GameScreen : UiScreen
{
    public UnityEngine.UI.Slider levelProgress;
    public UnityEngine.UI.Text levelProgressText;

    override public void Show(UiScreen caller = null)
    {
        base.Show(caller);
        Time.timeScale = 1;
    }

    public void OnPauseButtonClick()
    {
        GameManager.Instance.PauseScreen.Show(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : UiScreen
{
    private Text scoreText;

    public void Show(int score, UiScreen caller = null)
    {
        base.Show(caller);
        scoreText.text = $"Your Score: {score}";
    }

    public void OnTryAgainButtonClick()
    {
        GameManager.Instance.Restart();
        GameManager.Instance.GameScreen.Show(this);
    }
}

using UnityEngine.SceneManagement;

public class StartScreen : UiScreen
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}

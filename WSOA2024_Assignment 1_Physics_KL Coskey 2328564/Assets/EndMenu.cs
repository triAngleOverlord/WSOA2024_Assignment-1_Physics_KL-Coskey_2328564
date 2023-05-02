using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    public void PlayAgain()
    {
        SceneManager.LoadScene("Play");
        //GameManager.instance.UpdateGameState(GameManager.GameState.BeforePlay);
        GameManager.PlayerScore = 0;
        GameManager.ComputerScore = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

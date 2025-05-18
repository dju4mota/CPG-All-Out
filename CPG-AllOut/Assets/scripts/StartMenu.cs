using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button newGame;
    public Button quitGame;
    public Button tuturialButton;
    public Button voltar;
    public GameObject tuturial;


    private void Start()
    {
        newGame.onClick.AddListener(StartNewGame);
        quitGame.onClick.AddListener(Quit);
        tuturialButton.onClick.AddListener(TutorialActivate);
        voltar.onClick.AddListener(TutorialDeactivate);
    }

    private static void StartNewGame()
    {
        SceneManager.LoadScene("Felipe");
    }

    private static void Quit()
    {
        Application.Quit();
    }

    private void TutorialActivate()
    {
        tuturial.SetActive(true);  // ativa
    }
    private void TutorialDeactivate()
    {
        tuturial.SetActive(false);  // desativa
    }
}

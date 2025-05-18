using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public Button newGame;
    public Button quitGame;
    public Button tuturialButton;
    public Button voltar;
    public GameObject tuturial;
    public Image fadeOutImage;         // Atribua no Inspector
    public float fadeDuration = 1f;   // Tempo para o fade-in
    public Image fadeInImage;   

    private void Start()
    {
        newGame.onClick.AddListener(StartNewGame);
        quitGame.onClick.AddListener(Quit);
        tuturialButton.onClick.AddListener(TutorialActivate);
        voltar.onClick.AddListener(TutorialDeactivate);
    }

    private void StartNewGame()
    {
        //SceneManager.LoadScene("Cutscene");
         StartCoroutine(FadeOutImage(fadeInImage, fadeDuration));
         newGame.gameObject.SetActive(false);
         quitGame.gameObject.SetActive(false);
         tuturialButton.gameObject.SetActive(false);
    }

    private void Quit()
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

    IEnumerator FadeOutImage(Image targetImage, float duration)
    {
        Color color = targetImage.color;
        color.a = 0f;
        targetImage.color = color;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            color.a = Mathf.Lerp(0f, 1f, t);
            targetImage.color = color;

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Garante alpha final
        color.a = 1f;
        targetImage.color = color;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Cutscene");
    }
}

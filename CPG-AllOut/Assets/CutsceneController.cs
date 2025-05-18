using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Image image;           // Atribua no Inspector
    public float height = 2160f;   // Altura a subir (em unidades de UI, como pixels)
    public float duration = 1.5f;   // Tempo para completar o movimento
    public GameObject chapeuses;
    public GameObject Casa1;
    public GameObject Casa2;
    public Image fadeInImage;         // Atribua no Inspector
    public Image fadeOutImage;         // Atribua no Inspector
    public float fadeDuration = 2f;   // Tempo para o fade-in

    void Start()
    {
        StartCoroutine(StartAfterDelay());
    }

    IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(MoveUpWithAcceleration(height, duration));
    }

    IEnumerator MoveUpWithAcceleration(float totalHeight, float totalTime)
    {
        RectTransform rect = image.GetComponent<RectTransform>();
        Vector2 startPos = rect.anchoredPosition;
        Vector2 endPos = startPos + new Vector2(0, -totalHeight);

        float elapsed = 0f;

        while (elapsed < totalTime)
        {
            float t = elapsed / totalTime;

            // Aplicando uma curva de aceleração (t^2)
            float curvedT = 1 - Mathf.Pow(1 - t, 2);

            rect.anchoredPosition = Vector2.Lerp(startPos, endPos, curvedT);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Garante posição final exata
        rect.anchoredPosition = endPos;
        chapeuses.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeInImage(fadeInImage, fadeDuration));

    }

    IEnumerator FadeInImage(Image targetImage, float duration)
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
        Casa1.SetActive(true);
        yield return new WaitForSeconds(2f);
        Casa2.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOutImage(fadeOutImage, fadeDuration));
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
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Felipe");
    }
}

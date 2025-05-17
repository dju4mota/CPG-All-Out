using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsController : MonoBehaviour
{

    public Image image; // Assign in Inspector
    public TMP_Text pointText;
    public float duration = 2f; // Duration in seconds
    public float moveDistance = 100f; // Pixels to move up

    private CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = image.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = image.gameObject.AddComponent<CanvasGroup>();
        }

       
    }
    public void ShowPoints(int p)
    {
        pointText.text = $"+ {p}";
        StartCoroutine(FadeUpAndOut(duration, moveDistance));
    }

    IEnumerator FadeUpAndOut(float time, float distance)
    {
        RectTransform rect = image.GetComponent<RectTransform>();
        Vector2 startPos = rect.anchoredPosition;
        Vector2 endPos = startPos + new Vector2(0, distance);

        float elapsed = 0f;

        while (elapsed < time)
        {
            float t = elapsed / time;

            // Move image up
            rect.anchoredPosition = Vector2.Lerp(startPos, endPos, t);

            // Fade out
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure final state
        rect.anchoredPosition = endPos;
        canvasGroup.alpha = 0f;
        rect.anchoredPosition = startPos;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChapeuController : MonoBehaviour
{
    public Image image;

    [Header("Altura do flutuar")]
    public float minFloatHeight = 20f;
    public float maxFloatHeight = 40f;

    [Header("Velocidade de rotação")]
    public float minRotationSpeed = 45f;
    public float maxRotationSpeed = 180f;

    public float floatDuration = 1f;

    private float floatHeight;
    private float rotationSpeed;
    private RectTransform rect;
    private Vector2 startPos;

    void Start()
    {
        rect = image.GetComponent<RectTransform>();
        startPos = rect.anchoredPosition;

        floatHeight = Random.Range(minFloatHeight, maxFloatHeight);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        StartCoroutine(FloatAndRotate());
    }

    IEnumerator FloatAndRotate()
    {
        float time = 0f;

        while (true)
        {
            float t = Mathf.PingPong(time / floatDuration, 1f);
            float curvedT = Mathf.SmoothStep(0, 1, t);
            float yOffset = Mathf.Lerp(-floatHeight, floatHeight, curvedT);
            rect.anchoredPosition = startPos + new Vector2(0, yOffset);
            rect.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            time += Time.deltaTime;
            yield return null;
        }
    }
}

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TarefaController : MonoBehaviour
{
    public Image bgImage;
    public Image circleImage;
    public Sprite failSprite;
    public Sprite successSprite;

    public TMP_Text nome;
    public TMP_Text descricao;
    public float velocidade;

    private void Start()
    {
        nome.color = Color.black;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        circleImage.fillAmount += Time.deltaTime / velocidade;
        circleImage.fillAmount = Mathf.Clamp01(circleImage.fillAmount);

        if (circleImage.fillAmount == 1)
        {
            StartCoroutine(Fail());
        }
    }

    public void KillTask(bool sucess)
    {
        if (sucess)
        {
            StartCoroutine(Complete());
        }
        else
        {
             StartCoroutine(Fail());
        }
    }

    IEnumerator Complete()
    {
        bgImage.color = Color.green;
        circleImage.type = Image.Type.Simple;
        circleImage.sprite = successSprite;
        circleImage.color = Color.white;
        nome.color = Color.white;
        StartCoroutine(ScaleImageUp(0.25f));
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    IEnumerator Fail()
    {
        bgImage.color = Color.red;
        circleImage.type = Image.Type.Simple;
        circleImage.sprite = failSprite;
        circleImage.color = Color.white;
        nome.color = Color.white;
        StartCoroutine(ScaleImageUp(0.25f));
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);
    }
    
    IEnumerator ScaleImageUp(float time)
    {
        RectTransform rect = circleImage.GetComponent<RectTransform>();

        rect.localScale = Vector3.zero;
        float elapsed = 0f;

        while (elapsed < time)
        {
            float t = elapsed / time;
            rect.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure final scale is exactly 1
        rect.localScale = Vector3.one;
    }
}

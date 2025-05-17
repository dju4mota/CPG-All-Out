using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TarefaController : MonoBehaviour
{
    public Image bgImage;
    public Image circleImage; 

    public TMP_Text nome;
    public TMP_Text descricao;
    public float velocidade;

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        circleImage.fillAmount += Time.deltaTime/velocidade;
        circleImage.fillAmount = Mathf.Clamp01(circleImage.fillAmount);

        if(circleImage.fillAmount == 1){
            StartCoroutine(Fail());
        }
    }

    IEnumerator Complete(){
        bgImage.color = Color.green;
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    IEnumerator Fail(){
        bgImage.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}

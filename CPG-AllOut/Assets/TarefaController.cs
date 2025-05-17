using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TarefaController : MonoBehaviour
{
    public Image bgImage;
    public Image circleImage; 
    public float fillSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        circleImage.fillAmount += fillSpeed * Time.deltaTime;
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

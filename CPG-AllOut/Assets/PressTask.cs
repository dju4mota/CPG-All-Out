using UnityEngine;
using UnityEngine.UI;
public class PressTask : MonoBehaviour
{
    public Image circleImage; 
    public float fillSpeed = 10f;

    void Update()
    {
        if(Input.GetKey(KeyCode.M))
        {
            Debug.Log("subingo");
            circleImage.fillAmount += fillSpeed * Time.deltaTime;
            circleImage.fillAmount = Mathf.Clamp01(circleImage.fillAmount);
        }
        else
        {
            circleImage.fillAmount -= fillSpeed * Time.deltaTime;
            circleImage.fillAmount = Mathf.Clamp01(circleImage.fillAmount);
        }
    }
}

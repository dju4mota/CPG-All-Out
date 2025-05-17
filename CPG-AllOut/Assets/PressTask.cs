using System;
using UnityEngine;
using UnityEngine.UI;
public class PressTask : MonoBehaviour
{
    public Image circleImage; 
    public float fillSpeed;
    public Player player;
    public GameManager gameManager;
    Vector3 offset = new Vector3(2f, 2f, 0);

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        gameManager = FindFirstObjectByType<GameManager>();
        circleImage.rectTransform.position =  Camera.main.WorldToScreenPoint( player.transform.position + offset);
    }

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

        if (circleImage.fillAmount >= 1)
        {
            player.isTasking = false;
            gameManager.totalTasksAtivas--;
            Destroy(gameObject);
        }
    }
}
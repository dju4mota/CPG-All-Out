using System;
using UnityEngine;
using UnityEngine.UI;
public class PressTask : MonoBehaviour
{
    public Image circleImage; 
    public float fillSpeed;
    public Player player;
    public GameManager gameManager;
    public Task task;
    Vector3 offset = new(0f, 1f, 0);

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        gameManager = FindFirstObjectByType<GameManager>();
        circleImage.rectTransform.position =  Camera.main.WorldToScreenPoint(task.transform.position + offset);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.M))
        {
            player.isTasking = true;
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
            GameManager.i.pontuacao(1);
            Destroy(task.notificacao);
            task.gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}
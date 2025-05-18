using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PressTask : MonoBehaviour
{
    public Image circleImage; 
    public float fillSpeed;
    public Player player;
    public GameManager gameManager;
    public Task task;
    public int key;
    public TMP_Text keytext;
    public KeyCode keyCode;
    Vector3 offset = new(0f, 1f, 0);

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        gameManager = FindFirstObjectByType<GameManager>();
        circleImage.rectTransform.position = Camera.main.WorldToScreenPoint(task.transform.position + offset);
        switch (key)
        {
            case 0:
                keyCode = KeyCode.H;
                keytext.text = "H";
                break;
            case 1:
                keyCode = KeyCode.I;
                keytext.text = "I";
                break;
            case 2:
                keyCode = KeyCode.J;
                keytext.text = "J";
                break;
            default:
                keyCode = KeyCode.K;
                keytext.text = "K";
                break;
        }
    }

    void Update()
    {
        if(Input.GetKey(keyCode))
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
            task.CompleteTask();
            Destroy(task.notificacao);
            task.gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}
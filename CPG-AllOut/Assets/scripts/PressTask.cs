using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PressTask : MonoBehaviour
{
    public Sprite Circle;
    public Sprite Square;
    public Image image;
    public Image imageButton;
    public float fillSpeed;
    private float multiplierCafe = 1f;
    public Player player;
    public GameManager gameManager;
    public Task task;
    public int key;
    public TMP_Text keytext;
    public KeyCode keyCode;
    public bool isQTA;
    Vector3 offset = new(0f, 1f, 0);

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        gameManager = FindFirstObjectByType<GameManager>();
        image.rectTransform.position = Camera.main.WorldToScreenPoint(task.transform.position + offset);
        switch (key)
        {
            case 0:
                keyCode = KeyCode.H;
                keytext.text = "H";
                break;
            case 1:
                keyCode = KeyCode.J;
                keytext.text = "J";
                break;
            case 2:
                keyCode = KeyCode.K;
                keytext.text = "K";
                break;
            default:
                keyCode = KeyCode.L;
                keytext.text = "L";
                break;
        }

    }

    public void SetUp()
    {
        Debug.Log(isQTA);
        if (isQTA)
        {
            image.sprite = imageButton.sprite = Square;
            image.color = Color.red;
            image.fillMethod = Image.FillMethod.Vertical;
        }
        else
        {
            image.sprite = imageButton.sprite = Circle;
            image.color = Color.blue;
            image.fillMethod = Image.FillMethod.Radial360;
        }
    }

    void Update()
    {
        if (isQTA)
        {
            QTALogic();
        }
        else
        {
            HoldLogic();
        }

        if (player.cafeinado)
        {
            multiplierCafe = 1.5f;
        }
        else
        {
            multiplierCafe = 1f;
        }
    }

    void QTALogic()
    {
        if (Input.GetKeyDown(keyCode))
        {
            player.isTasking = true;
            Debug.Log("subingo");
            image.fillAmount += 0.3f * multiplierCafe;
            image.fillAmount = Mathf.Clamp01(image.fillAmount);
        }
        else
        {
            image.fillAmount -= fillSpeed * Time.deltaTime;
            image.fillAmount = Mathf.Clamp01(image.fillAmount);
        }

        if (image.fillAmount >= 1)
        {
            task._audio.clip = task.clip;
            task._audio.Play();
            player.isTasking = false;
            task.taskAtiva = false;
            gameManager.totalTasksAtivas--;
            task.CompleteTask();
            task.notificacao.GetComponent<TarefaController>().KillTask(true);
            task.gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }

    void HoldLogic()
    {
        if (Input.GetKey(keyCode))
        {
            player.isTasking = true;
            Debug.Log("subingo");
            image.fillAmount += fillSpeed * multiplierCafe * Time.deltaTime;
            image.fillAmount = Mathf.Clamp01(image.fillAmount);
        }
        else
        {
            image.fillAmount -= fillSpeed * Time.deltaTime;
            image.fillAmount = Mathf.Clamp01(image.fillAmount);
        }

        if (image.fillAmount >= 1)
        {
            task._audio.clip = task.clip;
            task._audio.Play();
            player.isTasking = false;
            task.taskAtiva = false;
            gameManager.totalTasksAtivas--;
            task.CompleteTask();
            task.notificacao.GetComponent<TarefaController>().KillTask(true);
            task.gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}
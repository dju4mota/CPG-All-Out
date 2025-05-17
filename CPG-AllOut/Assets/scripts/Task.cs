using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Task : MonoBehaviour
{
    public Player player;
    private SpriteRenderer spriteRenderer;
    public bool taskAtiva = false;
    [SerializeField]
    //public GameObject _PressTask;
    //public GameObject _QTATask;
    public GameObject TaskType;
    public GameObject PopUp;
    public Transform TaskManager;
    public bool isBeenDone;
    //
    public string nome;
    public string descricao;
    public float tempoMax;
    public float tempo;
    public GameObject notificacao;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void Inicia()
    {
        tempo = tempoMax;
        notificacao = HudController.i.CreateTask(nome, descricao, tempo);
        taskAtiva = true;
    }

    private void Update()
    {
        tempo -= Time.deltaTime;
        if (tempo <= 0)
        {
            player.isTasking = false;
            taskAtiva = false;
            Destroy(PopUp);
            Destroy(notificacao);
            gameObject.SetActive(false);
            GameManager.i.pontuacao(-1);
            GameManager.i.totalTasksAtivas--;
        }

        if (gameObject != null)
        {
            if (tempo < 2 * tempoMax / 3 && tempo > tempoMax/ 3)
            {
                StartCoroutine(Pisca(1));
            } 
            else if (tempo < tempoMax / 3)
            {
                StartCoroutine(Pisca(0.5f));
            }    
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Morgana"))
        {
            PopUp = Instantiate(TaskType, TaskManager, false);
            PopUp.GetComponent<PressTask>().task = this;

            isBeenDone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Morgana"))
        {
            isBeenDone = false;
            Destroy(PopUp);
        }
    }

    IEnumerator Pisca(float temp)
    {
        Debug.Log(temp);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        yield return new WaitForSeconds(temp);
    }
    
}
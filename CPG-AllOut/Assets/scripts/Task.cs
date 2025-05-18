using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


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
    public bool pisca = false;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void Inicia()
    {
        tempoMax = Random.Range(8, 16);
        spriteRenderer = GetComponent<SpriteRenderer>();
        tempo = tempoMax;
        notificacao = HudController.i.CreateTask(nome, descricao, tempo);
        taskAtiva = true;
        pisca = false;
        spriteRenderer.enabled = true;
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
            GameManager.i.totalTasksAtivas--;
            gameObject.SetActive(false);
        }
        
        if (gameObject != null)
        {
            if (tempo < tempoMax / 3)
            {
                ComecaPiscar();        
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Morgana"))
        {
            if (PopUp == null)
            {
                PopUp = Instantiate(TaskType, TaskManager, false);
                PopUp.GetComponent<PressTask>().task = this;
                PopUp.GetComponent<PressTask>().key = Random.Range(0, 4);
                Debug.Log(PopUp.GetComponent<PressTask>().isQTA = Random.Range(0, 2) == 1);
                PopUp.GetComponent<PressTask>().SetUp();
                isBeenDone = true;
            }
            else
            {
                PopUp.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Morgana"))
        {
            isBeenDone = false;
            PopUp.SetActive(false);
        }
    }

    private void ComecaPiscar()
    {
        if(pisca)
            return;
        pisca = true;
        StartCoroutine(Pisca(0.2f));
    }
    IEnumerator Pisca(float temp)
    {
        yield return new WaitForSeconds(temp);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        StartCoroutine(Pisca(temp));
    }

    public void CompleteTask()
    {
        GameManager.i.pontuacao((int)tempo*10);
    }


    public void FailTask()
    {
        GameManager.i.pontuacao(-(int)tempoMax);
    }
    
}
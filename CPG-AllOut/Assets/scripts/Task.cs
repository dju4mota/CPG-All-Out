using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Task : MonoBehaviour
{
    public Player player;
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
    private GameObject notificacao;
    

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
            taskAtiva = false;
            Destroy(PopUp);
            Destroy(notificacao);
            gameObject.SetActive(false);
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
    
}
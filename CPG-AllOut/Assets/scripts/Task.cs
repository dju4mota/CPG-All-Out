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
    public Transform TaskManager;

    public int total = 0;


    public void Inicia()
    {
        taskAtiva = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.isTasking = true;
            StartCoroutine(Fade());
            Instantiate(TaskType, TaskManager, false);
        }
    }

    private IEnumerator Fade(){
        yield return new WaitForSeconds(2f);
        gameManager.I.totalTasksAtivas--;
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
    
}

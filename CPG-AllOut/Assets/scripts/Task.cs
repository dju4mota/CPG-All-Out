using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Task : MonoBehaviour
{
    public Player player;
    public bool active = false;
    [SerializeField]
    //public GameObject _PressTask;
    //public GameObject _QTATask;
    public GameObject TaskType;
    public Transform TaskManager;

    public int total = 0;

    private void Start()
    {
        StartCoroutine(Fade());
        Instantiate(TaskType, TaskManager, false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player.isTasking = true;    
        active = true;
    }

    private IEnumerator Fade(){
        yield return new WaitForSeconds(1f);
    }
}

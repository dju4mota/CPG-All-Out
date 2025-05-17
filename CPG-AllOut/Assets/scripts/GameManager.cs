using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Task[] tasks;
    public int totalTasks;
    public int totalTasksAtivas;

    public float duracaoTotal;
    public float tempoEntreTasks;
    public float tempoTotal;
    public float tempoSemTask;
    public float tempoUltimaTask = 0;

    public int pontos;
    public int dinheiros; 
    
    void Start()
    {
        
    }
    
    void Update()
    {
        tempoTotal = Time.time;
        tempoSemTask = Time.time - tempoUltimaTask;
        if (tempoSemTask > tempoEntreTasks)
        {
            tempoUltimaTask = Time.time;
            tempoSemTask = 0;
            // gamedesign foda 
            sorteiaTask();
        }
    }

    void sorteiaTask() // sorteio ?? 
    {
        int index = Random.Range(0, tasks.Length);
        tasks[index].gameObject.SetActive(true);
        totalTasks++;
        totalTasksAtivas++;
    }
}

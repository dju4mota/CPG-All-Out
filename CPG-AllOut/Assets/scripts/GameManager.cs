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
    
    
    void Update()
    {
        tempoTotal = Time.time;
        tempoSemTask = Time.time - tempoUltimaTask;
        
        if (tempoSemTask > tempoEntreTasks)
        {
            tempoUltimaTask = Time.time;
            tempoSemTask = 0;

            switch (totalTasks) {
                case 0:
                case 1:
                    sorteiaTask();
                    break;
                case 2:
                    sorteiaTask();
                    sorteiaTask();
                    break;
                case 4:
                    sorteiaTask();
                    sorteiaTask();
                    sorteiaTask();
                    break;
                case 7: 
                    sorteiaTask();
                    sorteiaTask();
                    break;
                case >7:
                    sorteiaTask();
                    break;
            }
            
        }
    }

    void sorteiaTask() // sorteio ?? 
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            int index = Random.Range(0, tasks.Length);
            if(!tasks[index].taskAtiva)
            {
                tasks[index].gameObject.SetActive(true);
                tasks[index].taskAtiva = true;
                break;
            }

        }
        totalTasks++;
        totalTasksAtivas++;
        Debug.Log("Sorteia: " + totalTasks);
    }

    int sorteiaPosicao() {
        return Random.Range(5, 10);
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public Task[] tasks;
    public int totalTasks;
    public int totalTasksAtivas;
    public int tarefasFeitas;

    public float duracaoTotal;
    public float tempoEntreTasks;
    public float tempoTotal;
    public float tempoSemTask;
    public float tempoUltimaTask = 0;

    public int pontos;
    public int dinheiros; 
    public TMP_Text textoPontos;
    public TMP_Text textoTimer;
    
    void Start()
    {
  /*      if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (i != this)
        {
            Destroy(gameObject);
        }*/
        i = this;
    }
    
    void Update()
    {
        tempoTotal = Time.time;
        textoTimer.text = (duracaoTotal - tempoTotal).ToString("0.0");
        tempoSemTask = Time.time - tempoUltimaTask;
        if (tempoTotal >= duracaoTotal)
        {
            EndGame();
        }
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

    public void EndGame()
    {
        GameData.i.tarefasFeitas = tarefasFeitas;
        GameData.i.pontos = pontos;
        GameData.i.dinheiros = dinheiros;
        SceneManager.LoadScene("End");
    }

    public void pontuacao(int ponto)
    {
        pontos += ponto;
        textoPontos.text = "pontos: " + pontos;
        if (ponto == 1)
        {
            tarefasFeitas++;
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
                tasks[index].Inicia();
                totalTasksAtivas++;
                totalTasks++;
                break;
            }
        }
    }

    int sorteiaPosicao() {
        return Random.Range(5, 10);
    }
}
using System;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData i;

    public int pontos;
    public int dinheiros;
    public int tarefasFeitas;
    public int totalTasks;
    public GameManager gameManager;

    private void Start()
    {
        i = this;
        DontDestroyOnLoad(gameObject);
    }
    

    public void Update()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                Debug.Log("GameManager encontrado!");
            }
        }
        else
        {
            if (totalTasks < gameManager.tarefasFeitas)
            {
                totalTasks = gameManager.tarefasFeitas;
            }
        }
    }


}

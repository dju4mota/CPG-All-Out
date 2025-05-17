using System;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData i;
    
    public int pontos;
    public int dinheiros;
    public int tarefasFeitas;

    private void Start()
    {
        i = this;
        DontDestroyOnLoad(gameObject);
    }
}

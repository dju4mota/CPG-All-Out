using System;
using UnityEngine;
using UnityEngine.UI;


public class Task : MonoBehaviour
{
    public Player player;
    public bool active = false;
    [SerializeField]
    public Image imagem;

    public int total = 0;
    
    
    private void OnTriggerEnter(Collider other)
    {
        player.isTasking = true;
        active = true;
        Debug.Log("entrei");
        // ativa hud minigame 
    }

    private void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                imagem.fillAmount += 0.02f;
            }
        }
    }
}

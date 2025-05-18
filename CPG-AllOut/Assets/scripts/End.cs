using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Button newGame;
    public Button menu;
    public TMP_Text pontos;
    public TMP_Text dinheiro;
    public TMP_Text tarefas;
    public TMP_Text erros;
    public TMP_Text total;
    //Game manager pra pegar as tarefas feitas
    public AudioSource _audio;


    private void Start()
    {
        newGame.onClick.AddListener(StartNewGame);
        menu.onClick.AddListener(Menu);
        StartCoroutine("MostrarPontos");
    }

    private static void StartNewGame()
    {
        SceneManager.LoadScene("Felipe");
    }

    private static void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator MostrarPontos()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        pontos.text = (GameData.i.pontos).ToString();
        _audio.Play();
        StartCoroutine("MostrarDinheiro");
    }

    IEnumerator MostrarDinheiro()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        dinheiro.text = (GameData.i.dinheiros).ToString();
        _audio.Play();
        StartCoroutine("MostrarTarefas");
    }
    IEnumerator MostrarTarefas()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        tarefas.text = (GameData.i.tarefasFeitas).ToString();
        _audio.Play();
        StartCoroutine("MostrarTotal");
    }



    IEnumerator MostrarTotal()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        total.text = ((int)GameData.i.tarefasFeitas + (int)GameData.i.dinheiros + (int)GameData.i.pontos).ToString();
        _audio.Play();
    }

}

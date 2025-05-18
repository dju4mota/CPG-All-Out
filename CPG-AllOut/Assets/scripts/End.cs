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
        StartCoroutine("MostrarDinheiro");
    }

    IEnumerator MostrarDinheiro()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        dinheiro.text = (GameData.i.dinheiros).ToString();
        StartCoroutine("MostrarTarefas");
    }
    IEnumerator MostrarTarefas()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        tarefas.text = (GameData.i.tarefasFeitas).ToString();
        StartCoroutine("MostrarErros");
    }

    IEnumerator MostrarErros()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        int errosRestantes = Mathf.Max(0, GameData.i.totalTasks - GameData.i.tarefasFeitas);
        erros.text = errosRestantes.ToString();
        StartCoroutine("MostrarTotal");
    }



    IEnumerator MostrarTotal()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        total.text = "Total: " +( (int) GameData.i.tarefasFeitas + (int) GameData.i.dinheiros + (int) GameData.i.pontos);
    }

}

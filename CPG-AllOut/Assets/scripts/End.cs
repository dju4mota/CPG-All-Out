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
    public TMP_Text total;


    private void Start()
    {
        newGame.onClick.AddListener(StartNewGame);
        menu.onClick.AddListener(Menu);
        StartCoroutine("MostrarPontos");
    }

    private static void StartNewGame()
    {
        SceneManager.LoadScene("Dju");
    }

    private static void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator MostrarPontos()
    {
        yield return new WaitForSecondsRealtime(1f);
        pontos.text = "pontos: " + GameData.i.pontos;
        StartCoroutine("MostrarDinheiro");
    }

    IEnumerator MostrarDinheiro()
    {
        yield return new WaitForSecondsRealtime(1f);
        dinheiro.text = "dinheiro: " + GameData.i.dinheiros;
        StartCoroutine("MostrarTarefas");
    }
    IEnumerator MostrarTarefas()
    {
        yield return new WaitForSecondsRealtime(1f);
        tarefas.text = "tarefas: " + GameData.i.tarefasFeitas;
        StartCoroutine("MostrarTotal");
    }
    IEnumerator MostrarTotal()
    {
        yield return new WaitForSecondsRealtime(1f);
        total.text = "total: " +( (int) GameData.i.tarefasFeitas + (int) GameData.i.dinheiros + (int) GameData.i.pontos);
    }

}

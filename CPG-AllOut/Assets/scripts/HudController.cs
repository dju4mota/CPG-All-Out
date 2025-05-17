using UnityEngine;

public class HudController : MonoBehaviour
{
    public static HudController i;
    public GameObject Tarefa;
    public Transform TarefaBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (i != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject CreateTask(string nome, string descricao, float velocidade)
    {
        GameObject tarefa = Instantiate(Tarefa, TarefaBar);
        tarefa.GetComponent<TarefaController>().nome.text = nome;
        tarefa.GetComponent<TarefaController>().descricao.text = descricao;
        tarefa.GetComponent<TarefaController>().velocidade = velocidade;
        return tarefa;
    }
}

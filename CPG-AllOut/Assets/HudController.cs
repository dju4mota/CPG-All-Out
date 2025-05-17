using UnityEngine;

public class HudController : MonoBehaviour
{
    public GameObject Tarefa;
    public Transform TarefaBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            CreateTask();
        }
    }

    void CreateTask(){
        Instantiate(Tarefa, TarefaBar);
    }
}

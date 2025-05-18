using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public PointsController pointsController;
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
    //public TMP_Text textoPontos;
    public TMP_Text textoTimer;
    public TMP_Text textoDinheiro;
    public float tempoOffSetMenu;
    
    public AudioSource _audioSpawn;
    public float fadeDuration = 1f;   // Tempo para o fade-in
    public Image fadeInImage;   
    
    void Start()
    {
        tempoOffSetMenu = Time.time;
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
        pointsController = GetComponent<PointsController>();
    }
    
    void Update()
    {
        tempoTotal = Time.time - tempoOffSetMenu;
        textoTimer.text = (duracaoTotal - tempoTotal).ToString("0.0");
        tempoSemTask = Time.time - tempoUltimaTask - tempoOffSetMenu;
        if (tempoTotal >= duracaoTotal)
        {
            EndGame();
        }
        if (tempoSemTask > tempoEntreTasks)
        {
            tempoUltimaTask = Time.time - tempoOffSetMenu;
            tempoSemTask = 0;
            sorteiaTask();
         /*   switch (totalTasks) {
                case 0:
                case 1:
                    sorteiaTask();
                    break;
                case 2:
                    sorteiaTask();
                    sorteiaTask();
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                    sorteiaTask();
                    sorteiaTask();
                    sorteiaTask();
                    break;
                case >8: 
                    sorteiaTask();
                    sorteiaTask();
                    break;
            }*/
            
        }
    }

    public void EndGame()
    {
        GameData.i.tarefasFeitas = tarefasFeitas;
        GameData.i.pontos = pontos;
        GameData.i.dinheiros = dinheiros;
        StartCoroutine(FadeOutImage(fadeInImage, fadeDuration));
    }

    public void pontuacao(int ponto, int dinheiro)
    {
        pontos += ponto;
        pointsController.ShowPoints(ponto);
        dinheiros += dinheiro;
        textoDinheiro.text = "R$ " + dinheiros;
        if (ponto > 0f)
        {
            tarefasFeitas++;
        }

        
        
        
    }
    
    void ChangeVertexColor(Color newColor)
    {
        textoDinheiro.ForceMeshUpdate(); // Garante que a malha esteja atualizada

        TMP_TextInfo textInfo = textoDinheiro.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            Color32[] vertexColors = textInfo.meshInfo[materialIndex].colors32;

            vertexColors[vertexIndex + 0] = newColor;
            vertexColors[vertexIndex + 1] = newColor;
            vertexColors[vertexIndex + 2] = newColor;
            vertexColors[vertexIndex + 3] = newColor;
        }

        // Atualiza a malha com as novas cores
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
            textoDinheiro.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }

    void sorteiaTask() // sorteio ?? 
    {

        switch (totalTasks)
        {
            case 4:
                tempoEntreTasks = 3f;
                break;
            case 7:
                tempoEntreTasks = 2.5f;
                break;
            case 12:
                tempoEntreTasks = 2f;
                break;
        }

        for (int i = 0; i < tasks.Length; i++)
        {
            int index = Random.Range(0, tasks.Length);
            if(!tasks[index].taskAtiva)
            {
                tasks[index].gameObject.SetActive(true);
                tasks[index].taskAtiva = true;
                tasks[index].Inicia();
                _audioSpawn.Play();
                totalTasksAtivas++;
                totalTasks++;
                return;
            }
        }
    }

    IEnumerator FadeOutImage(Image targetImage, float duration)
    {
        Color color = targetImage.color;
        color.a = 0f;
        targetImage.color = color;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            color.a = Mathf.Lerp(0f, 1f, t);
            targetImage.color = color;

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Garante alpha final
        color.a = 1f;
        targetImage.color = color;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("End");
    }
}
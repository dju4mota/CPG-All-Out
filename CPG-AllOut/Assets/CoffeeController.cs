using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    public GameObject cafePopUp;
    public Player player;
    public float timer;
    private bool startTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)GameManager.i.tempoTotal == 15)
        {
            CafeQuentinho();
        }
        if (startTimer)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            player.Descafeinado();
            startTimer = false;
            timer = 5f;
        }
    }

    public void CafeQuentinho()
    {
        cafePopUp.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Morgana") && cafePopUp.activeSelf)
        {
            Debug.Log("Cafe");
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Ligou o cafe");
                cafePopUp.SetActive(false);
                player.Cafeinado();
                startTimer = true;
            }
        }
    }
}

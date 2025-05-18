using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    public GameObject cafePopUp;
    public Player player;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.i.textoTimer.text == "10.0")
        {
            CafeQuentinho();
        }
    }

    void CafeQuentinho()
    {
        cafePopUp.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Morgana") && cafePopUp.activeSelf)
        {
            Debug.Log("Cafe");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                cafePopUp.SetActive(false);
                player.Cafeinado();
                StartTimer();
            }
        }
    }

    private void StartTimer()
    {
        
    }
}

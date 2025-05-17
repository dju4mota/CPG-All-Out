using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical).normalized;

        if (movimento.magnitude >= 0.1f)
        {
            transform.Translate(movimento * velocidade * Time.deltaTime);
        }
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontal, vertical);

        private void FixedUpdate(){
            Vector3 movePosition = (speed * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
            rb.MovePosition(movePosition);
        }
    }
}

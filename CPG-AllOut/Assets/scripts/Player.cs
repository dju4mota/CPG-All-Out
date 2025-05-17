using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public bool isTasking;
    //public bool freeMovement;
    
    void Start()
    {        
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontal, vertical);
    }
    
    private void FixedUpdate(){
        if(isTasking)
            return;
        
        Vector3 movePosition = (speed * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(movePosition);
        
        if (moveDirection != Vector2.zero) 
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}

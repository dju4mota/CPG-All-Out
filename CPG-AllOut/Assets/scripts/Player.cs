using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    public Vector2 moveDirection;
    public CircleCollider2D coll;
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

        if(moveDirection != Vector2.zero)
            Render();
    }

    private void FixedUpdate()
    {
        if (isTasking)
            return;

        Vector3 movePosition = (speed * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(movePosition);

    }

    private void Render()
    {
        coll.offset = moveDirection.normalized * 1.5f;
    }
}

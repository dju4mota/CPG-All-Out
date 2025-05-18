using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 8f;
    private float speedcafe;
    public GameObject ghost;
    [SerializeField]
    private Rigidbody2D rb;
    public Vector2 moveDirection;
    public CircleCollider2D coll;
    public bool isTasking;
    public bool cafeinado;
    Vector3 movePosition;

    void Start()
    {
        speedcafe = 1.5f * speed;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontal, vertical);

        if (moveDirection != Vector2.zero)
            Render();

        if (ghost.activeSelf)
        {
            ghost.transform.localPosition = -moveDirection.normalized * 0.02f;
        }
    }

    public void Cafeinado()
    {
        cafeinado = true;
        ghost.SetActive(true);
    }
    
    public void Descafeinado()
    {
        cafeinado = false;
        ghost.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (isTasking)
            return;

        if (cafeinado)
        {
            movePosition = (speedcafe * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        }
        else
        {
            movePosition = (speed * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        }
        rb.MovePosition(movePosition);

    }

    private void Render()
    {
        coll.offset = moveDirection.normalized * 1.5f;
    }
}

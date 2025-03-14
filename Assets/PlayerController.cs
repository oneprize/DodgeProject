using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 10f;
    public float rotSpeed = 3f;
    public float jumpHeight = 3f;

    private Vector3 dir = Vector3.zero;
    private bool isGrounded = true; // ���� ���� ���� Ȯ��
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �̵� �Է�
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        // ���� �Է�
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;

            anim.SetBool("isWalking", dir != Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        // �̵� ó��
        Vector3 move = dir * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + move);

        // ȸ�� ó��
        if (dir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotSpeed * Time.fixedDeltaTime);
        }
    }

    // �ٴ� �浹 ����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

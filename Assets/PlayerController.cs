using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 10f;
    public float rotSpeed = 3f;
    public float jumpHeight = 3f;

    private Vector3 dir = Vector3.zero;
    private bool isGrounded = true; // 점프 가능 여부 확인
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
        // 이동 입력
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        // 점프 입력
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;

            anim.SetBool("isWalking", dir != Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        // 이동 처리
        Vector3 move = dir * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + move);

        // 회전 처리
        if (dir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotSpeed * Time.fixedDeltaTime);
        }
    }

    // 바닥 충돌 감지
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

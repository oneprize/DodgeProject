using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;
    public float speed = 5f;
    public float rotationSpeed = 700f;
    private Vector3 movement;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movement = new Vector3(moveX, 0, moveZ).normalized;

        // 애니메이션 속도 설정
        animator.SetFloat("Speed", movement.magnitude);
    }

    private void FixedUpdate()
    {
        // 이동 처리
        if (movement != Vector3.zero)
        {
            rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);

            // 캐릭터 회전
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime));
        }
    }
}

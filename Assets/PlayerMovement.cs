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
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movement = new Vector3(moveX, 0, moveZ).normalized;

        // �ִϸ��̼� �ӵ� ����
        animator.SetFloat("Speed", movement.magnitude);
    }

    private void FixedUpdate()
    {
        // �̵� ó��
        if (movement != Vector3.zero)
        {
            rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);

            // ĳ���� ȸ��
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime));
        }
    }
}

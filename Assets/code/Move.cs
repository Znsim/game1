using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float jumpForce = 10f; // ���� ��
    private bool isGrounded; // �ٴڿ� ��Ҵ��� ���θ� ��Ÿ���� ����

    public Animator animator; //�ִϸ����͸� �����Ѵ�.

    // Update �Լ��� �����Ӹ��� ȣ��˴ϴ�.
    void Update()
    {
        // �¿� �̵� ó��
        float moveInput = Input.GetAxisRaw("Horizontal"); // �¿� ȭ��ǥ �Ǵ� A, D Ű �Է��� �޽��ϴ�.
        float moveAmount = moveInput * moveSpeed * Time.deltaTime; // �̵����� ����մϴ�.

        // �̵����� ���� ��ġ�� ���մϴ�.
        transform.Translate(new Vector2(moveAmount, 0));

        //ĳ���͸� �¿�� ������
        if (moveInput > 0) // ���������� �̵� ��
        {
           animator.SetBool("Run", true);
            transform.localScale = new Vector3(1, 1, 1); // ĳ���͸� �������� �������ϴ�.
        }
        else if (moveInput < 0) // �������� �̵� ��
        {
            animator.SetBool("Run", true);
            transform.localScale = new Vector3(-1, 1, 1); // ĳ���͸� ���������� �������ϴ�.
        }
        else
        {
            animator.SetBool("Run", false);
        }

       

        // ���� ó��
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Space Ű�� ������ �ٴڿ� ����� ��
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // ���� ���� ���մϴ�.
            isGrounded = false; // �ٴڿ� ���� ���� ���·� �����մϴ�.
        }
    }

    // �ٴڿ� ��Ҵ��� ���θ� Ȯ���ϴ� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Ground �±׸� ���� ������Ʈ�� �浹���� ��
        {
            isGrounded = true; // �ٴڿ� ���� ���·� �����մϴ�.
        }
    }
}

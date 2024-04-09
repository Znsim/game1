using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float jumpForce = 10f; // 점프 힘
    private bool isGrounded; // 바닥에 닿았는지 여부를 나타내는 변수

    public Animator animator; //애니메이터를 참조한다.

    // Update 함수는 프레임마다 호출됩니다.
    void Update()
    {
        // 좌우 이동 처리
        float moveInput = Input.GetAxisRaw("Horizontal"); // 좌우 화살표 또는 A, D 키 입력을 받습니다.
        float moveAmount = moveInput * moveSpeed * Time.deltaTime; // 이동량을 계산합니다.

        // 이동량을 현재 위치에 더합니다.
        transform.Translate(new Vector2(moveAmount, 0));

        //캐릭터를 좌우로 뒤집기
        if (moveInput > 0) // 오른쪽으로 이동 중
        {
           animator.SetBool("Run", true);
            transform.localScale = new Vector3(1, 1, 1); // 캐릭터를 왼쪽으로 뒤집습니다.
        }
        else if (moveInput < 0) // 왼쪽으로 이동 중
        {
            animator.SetBool("Run", true);
            transform.localScale = new Vector3(-1, 1, 1); // 캐릭터를 오른쪽으로 뒤집습니다.
        }
        else
        {
            animator.SetBool("Run", false);
        }

       

        // 점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Space 키를 누르고 바닥에 닿았을 때
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // 점프 힘을 가합니다.
            isGrounded = false; // 바닥에 닿지 않은 상태로 변경합니다.
        }
    }

    // 바닥에 닿았는지 여부를 확인하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Ground 태그를 가진 오브젝트와 충돌했을 때
        {
            isGrounded = true; // 바닥에 닿은 상태로 변경합니다.
        }
    }
}

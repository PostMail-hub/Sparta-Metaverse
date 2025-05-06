using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MG_PlayerController : MonoBehaviour
{
    GameManager gameManager = null;

    public int PlayerHp = 3; // 유저의 생명력

    public int JumpNum = 0;
    public bool StartisGrounded = false;
    [SerializeField] public float PlayerSpeed = 0.05f; // 캐릭터 속도 조절 가능
    [SerializeField] float PlayerJumpPower = 19f; //캐릭터 점프력 조절 가능

    private Rigidbody2D plyerrb;

    void Start()
    {
        plyerrb = GetComponent<Rigidbody2D>();
        gameManager = GameManager.Instance;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            JumpNum = 2; // 점프 가능 횟수 설정
            StartisGrounded = true; // 시작할 때 바닥에 닿으면 앞으로 움직일 수 있도록 설정
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            gameManager.Damage();
        }
        else if (collision.gameObject.tag == "Score")
        {
            Debug.Log("점수 1점");
            gameManager.AddScore(1);
        }
    }

    void Update()
    {
        if (StartisGrounded)
        {
            transform.position += Vector3.right * PlayerSpeed; // 캐릭터 기본 우측 이동 출력
        }
        if (JumpNum > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            plyerrb.velocity = new Vector2(plyerrb.velocity.x, 0f);
            plyerrb.AddForce(Vector2.up * PlayerJumpPower, ForceMode2D.Impulse);
            JumpNum--;
        }
    }
}

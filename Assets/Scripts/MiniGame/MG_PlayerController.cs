using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MG_PlayerController : MonoBehaviour
{
    public AudioClip PlayerJumpClip;

    GameManager gameManager = null;

    public int PlayerHp = 3; // ������ �����

    public int JumpNum = 0;
    public bool StartisGrounded = false;
    [SerializeField] public float PlayerSpeed = 0.05f; // ĳ���� �ӵ� ���� ����
    [SerializeField] float PlayerJumpPower = 19f; //ĳ���� ������ ���� ����

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
            JumpNum = 2; // ���� ���� Ƚ�� ����
            StartisGrounded = true; // ������ �� �ٴڿ� ������ ������ ������ �� �ֵ��� ����
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
            MGScoreManager.Instance.AddScore(1);
        }
    }

    void Update()
    {
        if (StartisGrounded)
        {
            transform.position += Vector3.right * PlayerSpeed; // ĳ���� �⺻ ���� �̵� ���
        }
        if (JumpNum > 0 && Input.GetKeyDown(KeyCode.Space))
        {
                if (PlayerJumpClip != null)
                    SoundManager.PlayClip(PlayerJumpClip);
            plyerrb.velocity = new Vector2(plyerrb.velocity.x, 0f);
            plyerrb.AddForce(Vector2.up * PlayerJumpPower, ForceMode2D.Impulse);
            JumpNum--;
        }
    }
}

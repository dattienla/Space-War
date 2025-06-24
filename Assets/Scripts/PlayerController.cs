using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI scoreEndGameText;
    private float timeCanAttack;
    private bool canAttack;
    public static int count;
    int highScore;
    [SerializeField]
    TextMeshProUGUI highScoreText;
    public static AudioSource aud;
    [SerializeField]
    private AudioClip shootClip;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PositionCur();
        aud = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        CountScore();
    }
    void PositionCur()
    {
        Vector3 cur = transform.position;
        cur.x = Const.POS_MIN_X;
        transform.position = cur;
    }
    void Move()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Vector3 temp = transform.position;
            temp.y += Const.SPEED_MOVE * Time.deltaTime;
            if (temp.y > Const.POS_MAX_Y) temp.y = Const.POS_MAX_Y;
            transform.position = temp;

        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            Vector3 temp = transform.position;
            temp.y -= Const.SPEED_MOVE * Time.deltaTime;
            if (temp.y < Const.POS_MIN_Y) temp.y = Const.POS_MIN_Y;
            transform.position = temp;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Vector3 temp = transform.position;
            temp.x += Const.SPEED_MOVE * Time.deltaTime;
            if (temp.x > Const.POS_MAX_X) temp.x = Const.POS_MAX_X;
            transform.position = temp;

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Vector3 temp = transform.position;
            temp.x -= Const.SPEED_MOVE * Time.deltaTime;
            if (temp.x < Const.POS_MIN_X) temp.x = Const.POS_MIN_X;
            transform.position = temp;
        }
    }
    void Attack()
    {

        timeCanAttack += Time.deltaTime;
        if (timeCanAttack > 0.5f) // 0.5 giây bắn đc 1 lần
        {
            canAttack = true;
            timeCanAttack = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                aud.PlayOneShot(shootClip);
                Vector3 trans = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                Instantiate(bullet, trans, Quaternion.identity);
                canAttack = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" || col.tag == "ThienThach")
        {
            aud.Play();
            gameObject.GetComponent<Animator>().Play("playerDestroyAnim");
            Destroy(gameObject, 0.4f);
            GameManager.Instance.EndGamePanel();
        }
    }
    public void HighScore()
    {
        if (count > highScore)
        {
            PlayerPrefs.SetInt("HighScore", count);
            PlayerPrefs.Save();
            highScore = count;
        }
        highScoreText.text = highScore.ToString();
    }
    void CountScore()
    {
        scoreText.text = count.ToString();
        scoreEndGameText.text = count.ToString();
    }
    public static void BoomSound()
    {
        aud.Play();
    }
}

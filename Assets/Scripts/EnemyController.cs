using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speedMoveEnemy;
    [SerializeField]
    private float speedRotate;
    [SerializeField]
    private bool canRotate;
    [SerializeField]
    private bool canShoot;
    [SerializeField]
    private GameObject bullet;
    private float timeCanAttack;
    public static bool canAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speedMoveEnemy = Random.Range(3f, 7f);
        speedRotate = Random.Range(30f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        RotateEnemy();
        EnemyShoot();
    }
    void MoveEnemy()
    {
        Vector3 temp = transform.position;
        temp.x -= speedMoveEnemy * Time.deltaTime;
        if (temp.x < Const.POS_MIN_X - 2f) Destroy(gameObject);
        transform.position = temp;
    }
    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, speedRotate * Time.deltaTime));
        }
    }
    void EnemyShoot()
    {
        if (canShoot)
        {
            timeCanAttack += Time.deltaTime;
            if (timeCanAttack > Random.Range(2f, 5f))
            {
                canAttack = true;
                timeCanAttack = 0f;
            }
            if (canAttack)
            {
                Vector3 trans = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
                GameObject enemyBullet = Instantiate(bullet, trans, Quaternion.identity);
                enemyBullet.GetComponent<BulletController>().isEnemy = true;
                canAttack = false;
            }
        }

    }
}


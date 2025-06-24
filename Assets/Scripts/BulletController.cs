
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector]
    public bool isEnemy;
    private float dau = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isEnemy) dau = -1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }
    void MoveBullet()
    {
        Vector3 temp = transform.position;
        temp.x += (Const.SPEED_MOVE_BULLET * Time.deltaTime) * dau;
        transform.position = temp;
        if (temp.x > Const.POS_MAX_X + 2f || temp.x < Const.POS_MIN_X - 2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.tag == "Enemy")
        {
            PlayerController.count++;
            PlayerController.BoomSound();
            col.gameObject.GetComponent<Animator>().Play("enemyDestroyAnim");
            Destroy(col.gameObject, 0.4f);
            EnemyController.canAttack = false;
            Destroy(gameObject);
        }
        else if (col.tag == "ThienThach")
        {
            PlayerController.BoomSound();
            col.gameObject.GetComponent<Animator>().Play("thienThachDestroyAnim");
            Destroy(col.gameObject, 0.4f);
            Destroy(gameObject);
        }
        else if (col.tag == "Player")
        {
            PlayerController.BoomSound();
            col.gameObject.GetComponent<Animator>().Play("playerDestroyAnim");
            Destroy(col.gameObject, 0.4f);
            Destroy(gameObject);
            GameManager.Instance.EndGamePanel();
        }
    }


}

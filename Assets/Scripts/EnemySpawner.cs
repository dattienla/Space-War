using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject thienthach;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Spawner", 2f);
    }

    // Update is called once per frame
    void Spawner()
    {
        float[] temp = { 6.2f, 4.2f, 2.2f, 0.2f, -1.8f, -4f, -6.1f };
        int index = Random.Range(0, temp.Length);
        float posY = temp[index];
        Vector3 pos = gameObject.transform.position;
        pos.x = Const.POS_MAX_X +1f;
        transform.position = pos;
        Vector3 spawner = transform.position;
        spawner.y = posY;
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            Instantiate(enemy, spawner, Quaternion.Euler(0f, 0f, 90f));
        }
        else
        {
            Instantiate(thienthach, spawner, Quaternion.identity);
        }
        Invoke("Spawner", 2f);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{

    public float speed;
    private Transform player;
    private Vector2 target;
    public float TimeToLive = 5f;
    [SerializeField] private GameObject _explosionPrefab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

    }

    void Update()
    {

        Destroy(gameObject, TimeToLive);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        }
    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}




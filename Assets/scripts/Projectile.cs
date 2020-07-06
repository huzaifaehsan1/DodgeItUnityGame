using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;
    public float speed;
    private Transform player;
    private Vector2 target;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

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
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }

    void DestroyProjectile()
    {
        Destroy(gameObject);

    }



}

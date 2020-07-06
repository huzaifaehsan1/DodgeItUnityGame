using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    public float speed;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;


      
    void Start()
    {
        targetPosition = GetRandomPosition();
        timeBtwShots = startTimeBtwShots;
    }


    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

      
        Vector2 GetRandomPosition()
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            return new Vector2(randomX, randomY);
        }
    
}


using UnityEngine;
using System.Collections;
using System;

public class AppleTree : MonoBehaviour
{

    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves in meters/second
    public float speed = 1f;

    public AppleTree(GameObject applePrefab, float speed, float leftAndRightEdge, float chanceToChangeDirections, float secondsBetweenAppleDrops)
    {
        this.applePrefab = applePrefab;
        this.speed = speed;
        this.leftAndRightEdge = leftAndRightEdge;
        this.chanceToChangeDirections = chanceToChangeDirections;
        this.secondsBetweenAppleDrops = secondsBetweenAppleDrops;
    }

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        // Dropping apples every second
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

    

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);  // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate()
    {
        // Changing Direction Randomly
        if (UnityEngine.Random.value < chanceToChangeDirections)
        {
            speed *= -1;  // Change direction
        }
    }
}

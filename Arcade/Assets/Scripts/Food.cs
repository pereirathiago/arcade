using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomPosition();
    }

    private void Update()
    {
        ColliderFood();
    }

    void RandomPosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            RandomPosition();
        }
    }

    void ColliderFood()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if (this.transform.position == go.transform.position)
            {
                RandomPosition();
            }
        }
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardControl : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject Player;
    private float dropSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 7) {
            dropSpeed += 0.01f;
            transform.Translate(0, -1 * dropSpeed, 0);
            if (transform.position.y < -6) { Destroy(gameObject); }
            float xDist = transform.position.x - Player.transform.position.x;
            float yDist = transform.position.y - Player.transform.position.y;
            if (xDist * xDist + yDist * yDist < 0.7) { GameManager.GetComponent<GameManager>().Hit(); Destroy(gameObject); }
        }
    }
}

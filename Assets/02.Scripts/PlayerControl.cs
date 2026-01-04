using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float initialHeight;
    private float moveSpeed = 0.5f;
    private byte jump = 0x0;
    private static float upForce = 0.3f;
    private float vertSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.4) { transform.Translate(moveSpeed * -1, 0, 0); }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 8.4) { transform.Translate(moveSpeed, 0, 0); }
        if ((jump & 0x1) == 0 & Input.GetKeyDown(KeyCode.Space))
        {
            jump = 0x1;
            vertSpeed = upForce;
        }
        if ((jump & 0x1) != 0)      // CHALLENGE : double jump?
        {
            transform.Translate(0, vertSpeed, 0);
            vertSpeed -= upForce / 15;
            if (transform.position.y < initialHeight) {
                transform.Translate(0, initialHeight - transform.position.y, 0);
                jump = 0x0;
            }
        }

    }
}

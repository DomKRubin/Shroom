using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float moveSpeed;
	
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	
	void Update () {
        float x = Input.GetAxis("Vertical") * moveSpeed;
        float z = Input.GetAxis("Horizontal") * moveSpeed;

        x *= Time.deltaTime;
        z *= Time.deltaTime;

        transform.Translate(z, 0, x);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("left shift"))
        {
            moveSpeed *= 2;
        }

        if (Input.GetKeyUp("left shift"))
        {
            moveSpeed /= 2;
        }

    }
}

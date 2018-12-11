using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
    Vector2 mouseLook, smoothV;
    public float sensitivity, smoothing;

    private GameObject character;
	
	void Start () {
        character = this.transform.parent.gameObject;
	}

	void Update () {
        //Recieve mouse direction
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //Apply smoothing and sensitivity
        md = Vector2.Scale(md, new Vector2((sensitivity * smoothing), (sensitivity * smoothing)));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -85, 85);

        //print(mouseLook.y);

        if (Input.GetKeyDown("escape"))
        {
            sensitivity = 0;
            smoothing = 0;
        }

        //Use the new attributes to move the Camera
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour {
    public GameObject obj;
    public float rotatespeed;
    private float h;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset=transform.position - obj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Mouse X");
        if (h != 0)
        {
            transform.RotateAround(obj.transform.position,Vector3.up, h*rotatespeed);
        }
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update () {
        ProcessInput();
    }

    void ProcessInput() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidbody.AddRelativeForce(Vector3.up);
        }
        if (Input.GetKey(KeyCode.A)) {
            rigidbody.AddForce(Vector3.left);
        } else if (Input.GetKey(KeyCode.D)) {
            rigidbody.AddForce(Vector3.right);
        }
    }
}

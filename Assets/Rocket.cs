using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField]
    float rcsThrust = 100f;

    [SerializeField]
    float mainThrust = 100f;

    Rigidbody rigidbody;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update () {
        ProcessInput();
    }

    void ProcessInput() {
        HandleThrusting();
        HandleRotation();
    }

    private void HandleRotation() {
        rigidbody.freezeRotation = true;
        float rotationForFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * rotationForFrame);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.back * rotationForFrame);
        }
        rigidbody.freezeRotation = false;
    }

    private void HandleThrusting() {
        float thrustForFrame = mainThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)) {
            rigidbody.AddRelativeForce(Vector3.up * thrustForFrame);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }
}

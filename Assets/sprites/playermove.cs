using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlayer : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody body;
    public float speed = 2;
    private Vector3 offset;
    public float smoothCamera = 2;

    private void Start()
    {
        offset = transform.position - Camera.main.transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 input = joystick.Direction;
        Vector3 worldInput = Camera.main.transform.TransformDirection(input);
        worldInput.y = 0;

        body.AddForce(worldInput * speed);
    }

    void Update()
    {
        Vector3 currentPos = Camera.main.transform.position;
        Vector3 destinationPos = transform.position - offset;
        Camera.main.transform.position = Vector3.Lerp(currentPos, destinationPos, Time.deltaTime * smoothCamera);
    }
}

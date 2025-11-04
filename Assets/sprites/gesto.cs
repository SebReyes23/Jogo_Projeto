using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gesto : MonoBehaviour
{
    //public Joystick joystick;
    public Rigidbody body;
    public float speed = 2;

    //Camera
    private Vector3 offset;
    public float smoothCamera = 2;

    //Touch
    private Vector2 touchInitPos;

    private void Start()
    {
        offset = transform.position - Camera.main.transform.position;
    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchInitPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 deltaPos = touch.position - touchInitPos;

                //Vector2 input = joystick.Direction;
                Vector3 worldInput = Camera.main.transform.TransformDirection(deltaPos);
                worldInput.y = 0;

                body.AddForce(worldInput * speed);

            }
        }

        //Camera Follow
        Vector3 currentPos = Camera.main.transform.position;
        Vector3 destinationPos = transform.position - offset;
        Camera.main.transform.position = Vector3.Lerp(currentPos, destinationPos, Time.deltaTime * smoothCamera);
    }
}
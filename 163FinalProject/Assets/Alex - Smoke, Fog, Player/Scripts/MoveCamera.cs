using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private bool mouse = false;

    private float speed;
    private float shiftSpeed;

    private Vector2 rotation;

    private void Start()
    {
        //initialize rotation
        rotation = new Vector2(0, 0);

        //make mouse invisible
        if(!mouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        //initialize speeds
        shiftSpeed = 3 * moveSpeed;
        speed = moveSpeed;
    }

    private void Update()
    {
        //update rotation
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * rotateSpeed;

        //movement
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        //up/down movement
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }


        //check speed up
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = shiftSpeed;
        }
        else
        {
            speed = moveSpeed;
        }

        //quit build
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

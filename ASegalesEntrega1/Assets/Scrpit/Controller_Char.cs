using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Controller_Char : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 7;

    public float jumpSpeed;
    public float ySpeed;
    private CharacterController characterController;
    public TextMeshProUGUI points;
    private int pointsNumber = 0;

    Rigidbody rb;
    Animator c_Animator;
    void Start()
    {
        c_Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = pointsNumber.ToString();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, 0);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;
        Vector3 velocity = movementDirection * magnitude;



        if (characterController.isGrounded)
        {
            ySpeed = -0.5f;
            if (Input.GetKey(KeyCode.Space))
            {
                ySpeed = jumpSpeed;
            }
        }

        velocity.z = speed;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            c_Animator.SetBool("Dead", true);
            characterController.enabled = false;
            Invoke("Restart", 3);
        }
        if (other.tag == "Coin")
        {
            pointsNumber += 10;
            Destroy(other.gameObject);
        }
    }
    private void Restart() 
    {
        SceneManager.LoadScene(0);
    }
}
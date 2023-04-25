using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 7;
    Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        if (Input.GetKey(KeyCode.LeftArrow)) { 
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
            Animator.SetTrigger(LeftRun);
        }
        if (Input.GetKey(KeyCode.RightArrow)) { 
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            Animator.SetTrigger(RightRun);
        }
    }
}

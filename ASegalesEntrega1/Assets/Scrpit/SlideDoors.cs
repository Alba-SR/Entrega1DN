using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoors : MonoBehaviour
{
    // Start is called before the first frame update
    public float move = 3;
    public GameObject doorLeft;
    public GameObject doorRight;
    private bool doorOpen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        doorLeft.GetComponent<Animator>().Play("SlidingDoor1Open");
        doorRight.GetComponent<Animator>().Play("SlidingDoor2Open");
    }

}

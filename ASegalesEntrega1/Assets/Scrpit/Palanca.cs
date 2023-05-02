using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationActive = -50;
    public float gachaDistance = -10;
    public GameObject palanca;
    public GameObject Gacha;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            palanca.transform.Rotate(0, 0, rotationActive);
            Gacha.SetActive(true);
        }
    }
}

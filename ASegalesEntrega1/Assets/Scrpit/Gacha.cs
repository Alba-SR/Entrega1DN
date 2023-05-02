using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    // Start is called before the first frame update
    public float upSpeed = 3;
    public float downSpeed = 15;
    Animator animator;
    private bool MoveUP = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy) 
        {
            if (transform.position.y > 3) 
            {
                animator.SetBool("TurnedOn", true);
                transform.position = new Vector3(transform.position.x, transform.position.y - upSpeed * Time.deltaTime, transform.position.z);
            }
            if (MoveUP) 
            {
                if (transform.position.y < 12)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + downSpeed * Time.deltaTime, transform.position.z);
                }
                else 
                {
                    MoveUP = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void GachaEnded() 
    {
        animator.SetBool("TurnedOn", false);
        Debug.Log("patata");
        Invoke("NowMove", 1);
    }
    public void NowMove() 
    {
        MoveUP = true;
        Debug.Log("Patata2");
    }
}

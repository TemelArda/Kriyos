using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    Rigidbody rigidbody;
    public GameObject nearbyIntObj;
    public bool intTypeisPull;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
        }
        if (Input.GetAxis("Horizontal")==-1 || Input.GetAxis("Horizontal") == 1)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        GetInterractable();
      
        if (Input.GetKey(KeyCode.E) && Vector3.Distance(transform.position,nearbyIntObj.transform.position)<2f)
        {
            Debug.Log("pass");
            if (intTypeisPull)
            {
                if (nearbyIntObj != null) 
                {
                    nearbyIntObj.transform.parent = transform;
                    animator.SetBool("pull", true);
                }
            }
            else
            {
                if (nearbyIntObj != null)
                {
                    nearbyIntObj.transform.parent = transform;
                    animator.SetBool("push", true);
                }
            }
        }
        else
        {
            nearbyIntObj.transform.parent = null;
            animator.SetBool("pull", false);
            animator.SetBool("push", false);
        }
    }

    private void GetInterractable()
    {
        GameObject[] ints = GameObject.FindGameObjectsWithTag("Interractable");
        nearbyIntObj = ints[0];
        intTypeisPull = nearbyIntObj.GetComponent<Interractable>().isPulling;
        foreach (GameObject objs in ints)
        {
            if (Vector3.Distance(nearbyIntObj.transform.position, transform.position) >
                Vector3.Distance(objs.transform.position, transform.position))
            {
                nearbyIntObj = objs;
                intTypeisPull = objs.GetComponent<Interractable>().isPulling;
            }
        }
    }
}

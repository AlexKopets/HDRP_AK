using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GirlController : MonoBehaviour
{
    private Animator animGirl;
    private bool flagTag=false;
    [HideInInspector] public bool flagFinalAnim = false;
    // Start is called before the first frame update
    void Start()
    {
        animGirl = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Dialog").GetComponent<GameManager>().score == 3 && flagTag==true)
        {
            animGirl.SetTrigger("Final");
            flagFinalAnim = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
           
            flagTag = true;

        }
        

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {

            flagTag =false;

        }


    }
}

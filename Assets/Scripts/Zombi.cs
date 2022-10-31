using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    private Animator animZombi;
   
    // Start is called before the first frame update
    void Start()
    {
        animZombi = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerController>().flagZombiAnim ==true)
        {
            animZombi.SetTrigger("Death");
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animZombi.SetTrigger("ZombiAttack");
            
        }
    }
}

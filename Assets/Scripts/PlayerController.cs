using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [HideInInspector] public bool flagDialog=false;
    public TextMeshProUGUI dialogText;
    private CharacterController controller;
    private Animator anim;
    float xMovement;
    float zMovement;
    private bool flagTag=false;
    [HideInInspector] public bool flagMove;
    [HideInInspector] public int zombiPoint = 1;
    private GameManager gameManager;
    [HideInInspector] public bool zombiFlag=false;
    [HideInInspector] public bool flagZombiAnim = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        gameManager = GameObject.Find("Dialog").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");
        if (flagMove == false)
        {
            if (xMovement != 0 || zMovement != 0)
            {
                Vector3 move = transform.right * xMovement + transform.forward * zMovement;
                controller.Move(move * speed * Time.deltaTime);
                anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);

            }
            else
            {
                anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0)&&zombiFlag==true)
            {
                StartCoroutine(Attack());
                zombiPoint=1;
                gameManager.UpdateScore(zombiPoint);
                flagZombiAnim=true;
            }
        }
       
        if (Input.GetKeyDown(KeyCode.E)&&flagTag==true)
        {
            flagDialog = true;
            dialogText.gameObject.SetActive(false);
            
        }

    }
   private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
    }
     private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Girl") 
        {
            dialogText.gameObject.SetActive(true);
            flagTag = true;
          
        }
        if (other.tag == "Zombi" )
        {
              zombiFlag=true;
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Girl")
        {
            dialogText.gameObject.SetActive(false);
            flagDialog=false;
            flagTag = false;
        }
        if (other.tag == "Zombi")
        {
              zombiFlag = false;
           
        }
    }

}

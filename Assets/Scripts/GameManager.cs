using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera dialogCamera;
    public TextMeshProUGUI dialogText1;
    private bool flagQvest=false;
    public GameObject zombi;
    public GameObject zombi2;
    public GameObject zombi3;
    public TextMeshProUGUI qvestText;
    [HideInInspector] public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().flagDialog==true)
        {
            firstPersonCamera.enabled=false;
            dialogCamera.enabled=true;
            GameObject.Find("Player").GetComponent<PlayerController>().flagMove=true;
            dialogText1.gameObject.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerController>().flagDialog = false;
            flagQvest=true;
            if(GameObject.Find("Dialog").GetComponent<GameManager>().score == 3)
            {
                dialogText1.text = "YOU WIN!";
            }
            else
            {
                dialogText1.text = "Kill two zombies! Yes (press R) No (press Q)";
            }
            
        }
        if (Input.GetKeyDown(KeyCode.R)&&flagQvest==true)
        {
            firstPersonCamera.enabled = true;
            dialogCamera.enabled = false;
            GameObject.Find("Player").GetComponent<PlayerController>().flagMove = false;
            dialogText1.gameObject.SetActive(false);
            zombi.SetActive(true);
            zombi2.SetActive(true);
            zombi3.SetActive(true);
            qvestText.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.Q) && flagQvest == true)
        {
            firstPersonCamera.enabled = true;
            dialogCamera.enabled = false;
            GameObject.Find("Player").GetComponent<PlayerController>().flagMove = false;
            dialogText1.gameObject.SetActive(false);
            flagQvest=false;

        }
      
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        qvestText.text = "Zombies killed: " + score+" /3";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigArm : MonoBehaviour
{
    private Rig rigArm;
    // Start is called before the first frame update
    void Start()
    {
        rigArm = GetComponent<Rig>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (GameObject.Find("SerahBikini").GetComponent<GirlController>().flagFinalAnim == true)
                rigArm.weight = 1.0f;
        }
    }
}

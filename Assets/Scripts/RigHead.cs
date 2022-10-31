using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class RigHead : MonoBehaviour
{
    private Rig rigHead;

    // Start is called before the first frame update
    void Start()
    {
        rigHead = GetComponent<Rig>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("SerahBikini").GetComponent<GirlController>().flagFinalAnim == true)
            rigHead.weight = 1.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var camForward = Camera.main.transform.forward;
        
        transform.LookAt(transform.position + camForward);
    }
}

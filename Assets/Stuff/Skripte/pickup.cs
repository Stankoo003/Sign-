using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        //Destroy(this.gameObject);
        GameObject temp = this.gameObject;
        temp.transform.localScale = new Vector3(0f,0f,0f);
        signscore.signtext++;

        
    }
}

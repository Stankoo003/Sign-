using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class signscore : MonoBehaviour
{
    Text SIGN;
    public static int signtext = 0;

    void Start()
    {
        SIGN = GetComponent<Text>();
    }

    void Update()
    {
        SIGN.text = "Sign:  " + signtext + "/5";
        
        
    }
}

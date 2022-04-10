using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelhandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void s1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void exit()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.LoadLevel("SceneName");
        }


    }
}

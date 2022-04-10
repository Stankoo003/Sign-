using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class JumpTrigger : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject ThePlayer;
    public GameObject JumpCam;
    public GameObject FlashImg;
    private bool Passed = false;

    void OnTriggerEnter()
    {
        if (!Passed)
        {
            Scream.Play();
            JumpCam.SetActive(true);
            ThePlayer.SetActive(false);
            FlashImg.SetActive(true);
            StartCoroutine(EndJump());
            Passed = true;
        }
    }
    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
        ThePlayer.SetActive(true);
        JumpCam.SetActive(false);
        FlashImg.SetActive(false);
    }
}


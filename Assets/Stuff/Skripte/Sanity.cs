using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sanity : MonoBehaviour
{
    private float sanity;
    private bool darkness=false;
    private bool batteryDarkness = false;
    private float battery;
    private float desiredBattery = 15f;
    private bool batteryRefillState=false;
    public Light lampa;
    public Slider lampSlider;
    public Slider sanitySlider;
    public GameObject player;
    private CharacterController CC;
    void Start()
    {
        sanity=100f; 
        battery=20f;
        CC = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        checkSanity();
        batteryDrainage();
        lampSlider.value = battery;
        sanitySlider.value = sanity;

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("exit");
        }
    }

    private void checkSanity(){
        if(sanity<=0){
            CC.enabled=false;
            player.transform.position = new Vector3(80,9f,-92f);
            CC.enabled = true;
        }
        if(darkness){
            sanity-=0.8f*Time.deltaTime;
        }   

        if(batteryDarkness){
            sanity-=2.1f*Time.deltaTime;
        }
        Debug.Log(sanity+" "+battery);
    }

    private void batteryDrainage(){
        if(battery>=0&&batteryRefillState==false){
            batteryDarkness=false;
            battery-=1.2f*Time.deltaTime;
            lampa.intensity =2;
        }else{
            batteryDarkness=true;
            lampa.intensity=0;
            batteryRefillState=true;
        }
        if(batteryRefillState){
            if(battery>=20){
                batteryRefillState=false;
            }
            battery+=1.4f*Time.deltaTime;
        }


    }



}

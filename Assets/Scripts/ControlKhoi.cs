using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlKhoi : MonoBehaviour
{
    public GameObject Player;
    public Vector3 temp;
    public float moveSpeed = 10;
    void Start(){
        
    }
    void Update () {
        try{
            if(Player != null){
                //temp =new Vector3(-1, 0.1f, 0);
                Vector3 targetPos = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);
                Vector3 velocity = (targetPos+temp - transform.position) * moveSpeed;
                transform.position = Vector3.SmoothDamp (transform.position, targetPos+temp, ref velocity, 1.0f, Time.deltaTime);
            }
        }
        catch (Exception error){
            //Debug.Log(error.Message);
        }
    }
}

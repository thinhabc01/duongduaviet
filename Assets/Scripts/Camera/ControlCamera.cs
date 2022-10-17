using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ControlCamera : MonoBehaviour
{
    [SerializeField] private float MinX= -11,MaxX = 270,MinY = 5, MaxY = 6;
    [SerializeField] private GameObject Player;
    //public Transform followTarget;
    private Vector3 targetPos;
    [SerializeField] private float moveSpeed = 4;
    GameObject Player1;
	GameObject Player2;
	GameObject Player3;
	GameObject Player4;
    void Start(){
    }
    void Update () {
        try{
            if(Player != null)
            {
                targetPos = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
                if (targetPos.y>MaxY){
                    targetPos.y = MaxY;
                }
                else if (targetPos.y<MinY){
                    targetPos.y = MinY;
                }
                if (targetPos.x>MaxX){
                    targetPos.x = MaxX;
                }
                else if (targetPos.x<MinX){
                    targetPos.x = MinX;
                }
                Vector3 velocity = (targetPos - transform.position) * moveSpeed;
                transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
                
            }
            else{
                Player1 = GameObject.FindWithTag("play1");
		        Player2 = GameObject.FindWithTag("play2");
		        Player3 = GameObject.FindWithTag("play3");
		        Player4 = GameObject.FindWithTag("play4");
                if(Player1.GetComponent<ControlPlay>().isPlayer){
                     Player = Player1;
                }
                if(Player2.GetComponent<ControlPlay>().isPlayer){
                     Player = Player2;
                }
                if(Player3.GetComponent<ControlPlay>().isPlayer){
                     Player = Player3;
                }
                if(Player4.GetComponent<ControlPlay>().isPlayer){
                     Player = Player4;
                }
            }
        }
        catch (Exception error){
            //Debug.Log(error.Message);
        }
    }
}

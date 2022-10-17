using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayMove : MonoBehaviour
{
    public bool start = false, win = false;
    private Rigidbody2D Rg;
    private Transform Tr;
    private Collider2D Cd;
    private SpriteRenderer Sr;
    private Animator An;
    [SerializeField] private enum StateRun{Dtot, Dxau, Dlay, Nuoc, Jump}
    [SerializeField] private StateRun PlayerStateRun;
    [SerializeField] private float speedTot,speedXau,speedLay,speedNuoc;
    private float speed = 0;
    [SerializeField] private float Speed;
    [SerializeField] private float jump;
    public bool isGround = false, isWater = false, isTangtoc = false;
    public bool jumppoint = false;
    // Start is called before the first frame update
    void Start()
    {
        Speed = speedTot;
        Rg = GetComponent<Rigidbody2D>();
        Tr = GetComponent<Transform>();
        Cd = GetComponent<Collider2D>();
        Sr = GetComponent<SpriteRenderer>();
        An = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        if (start){
            if(isGround){
                An.SetBool("jump", false);
            }
            else{
                Speed = 3f;
            }
            if (GetComponent<ControlPlay>().isPlayer){
                if (Input.GetKey("right")){
                    Tr.localScale = new Vector3(1,1,0);
                    Rg.velocity = new Vector3(speed + Speed, Rg.velocity.y, 0);
                }
                else if (Input.GetKey("left")){
                    Rg.velocity = new Vector3(-1*(speed + Speed), Rg.velocity.y, 0);
                    Tr.localScale = new Vector3(-1,1,0);
                    }
                if(Input.GetKey("up") && isGround){
                    An.SetBool("jump", true);
                    Rg.velocity = new Vector3(Rg.velocity.x, jump, 0);
                    PlayerStateRun = StateRun.Jump;
                    //Speed = 3f;//(speedTot+speedXau+speedLay+speedNuoc)/4-0.5f;
                }
            }
            else{
                Rg.velocity = new Vector3(speed + Speed, Rg.velocity.y, 0);
                if(jumppoint && isGround){
                    jumppoint = false;
                    An.SetBool("jump", true);
                    Rg.velocity = new Vector3(Rg.velocity.x, jump, 0);
                    PlayerStateRun = StateRun.Jump;
                    //Speed = 3f;//(speedTot+speedXau+speedLay+speedNuoc)/4-0.5f;
                }
            }
        }
        //Debug.Log(speed+Speed);
    }
    void OnCollisionEnter2D(Collision2D other){
        try{
            Vector3 temp = Tr.position - other.gameObject.transform.position;
            if(temp.y>=1){
                if (other.gameObject.tag.Equals("ground")){
                    isGround = true;
                }
                if (other.gameObject.tag.Equals("dtot")){
                    isGround = true;
                    if(!isWater && !isTangtoc){
                        PlayerStateRun = StateRun.Dtot;
                        Speed = speedTot;
                    }
                }
                if (other.gameObject.tag.Equals("dxau")){
                    isGround = true;
                    if(!isTangtoc){
                        PlayerStateRun = StateRun.Dxau;
                        Speed = speedXau;
                    }
                }
                if (other.gameObject.tag.Equals("dlay")){
                    isGround = true;
                    if(!isTangtoc){
                        PlayerStateRun = StateRun.Dlay;
                        Speed = speedLay;
                    }
                }
            }
            else{
                
            }
        }
        catch (Exception error){}
    }
    void OnCollisionStay2D(Collision2D other){
        Vector3 temp = Tr.position - other.gameObject.transform.position;
        if(temp.y>=1){
            if (other.gameObject.tag.Equals("ground")){
                isGround = true;
            }
            if (other.gameObject.tag.Equals("dtot")){
                isGround = true;
                if(!isWater && !isTangtoc){
                    PlayerStateRun = StateRun.Dtot;
                    Speed = speedTot;
                }
            }
            if (other.gameObject.tag.Equals("dxau")){
                isGround = true;
                if(!isTangtoc){
                    PlayerStateRun = StateRun.Dxau;
                    Speed = speedXau;
                }
            }
            if (other.gameObject.tag.Equals("dlay")){
                isGround = true;
                if(!isTangtoc){
                    PlayerStateRun = StateRun.Dlay;
                    Speed = speedLay;
                }
            }
        }
        else{
            
        }
    }
    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag.Equals("ground")){
            isGround = false;
        }
        if (other.gameObject.tag.Equals("dtot")){
            isGround = false;
        }
        if (other.gameObject.tag.Equals("dxau")){
            isGround = false;
        }
        if (other.gameObject.tag.Equals("dlay")){
            isGround = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("jumppoint")){
            jumppoint = true;
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag.Equals("water")){
            isWater = true;
            if(!isTangtoc){
                PlayerStateRun = StateRun.Nuoc;
                Speed = speedNuoc;
            }
        }
        if (other.gameObject.tag.Equals("jumppoint")){
            jumppoint = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag.Equals("water")){
            isWater = false;
            PlayerStateRun = StateRun.Jump;
        }
        if (other.gameObject.tag.Equals("jumppoint")){
            jumppoint = false;
        }
    }
    public IEnumerator tangtoc(){
        isTangtoc = true;
        speed +=5;
		yield return new WaitForSeconds (3);
        speed -=5;
        isTangtoc = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WControl : MonoBehaviour
{
	GameObject camera;
    Transform Tr;
    // Start is called before the first frame update
    void Start(){
		camera = GameObject.FindWithTag("MainCamera"); 
        Tr = camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 temp = transform.position;
        Vector3 Vspeed = new Vector3(1, 0, 0);
        transform.position = temp + Vspeed*Time.deltaTime;
        Debug.Log(Tr.position.x + Screen.width);
        Debug.Log( transform.position.x);
        if(transform.position.x > Tr.position.x + Screen.width){
            transform.position = new Vector3(Tr.position.x-2*Screen.width,transform.position.y,0);
        }
        if(transform.position.x < Tr.position.x - Screen.width){
            transform.position = new Vector3(Tr.position.x+2*Screen.width,transform.position.y,0);
        }
    }
    // void OnTriggerEnter2D(Collider2D other){
    //     if (other.gameObject.tag.Equals("backleft")){
    //         Vector3 temp = backright.transform.position;
    //         transform.position = new Vector3(temp.x-2,transform.position.y,0);
    //     }
    //     if (other.gameObject.tag.Equals("backright")){
    //         Vector3 temp = backleft.transform.position;
    //         transform.position = new Vector3(temp.x+2,transform.position.y,0);
    //     }
    // }  
}

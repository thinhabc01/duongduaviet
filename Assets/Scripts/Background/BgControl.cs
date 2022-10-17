using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    GameObject backright;
	GameObject backleft;
    // Start is called before the first frame update
    void Start(){
        backright = GameObject.FindWithTag("backright");
		backleft = GameObject.FindWithTag("backleft");       
    }

    // Update is called once per frame
    void Update(){}
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("backleft")){
            Vector3 temp = backright.transform.position;
            transform.position = new Vector3(temp.x-2,transform.position.y,0);
        }
        if (other.gameObject.tag.Equals("backright")){
            Vector3 temp = backleft.transform.position;
            transform.position = new Vector3(temp.x+2,transform.position.y,0);
        }
    }  
}

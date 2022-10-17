using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCho : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float time = 1.5f;
    float Speed;
    // Start is called before the first frame update
    void Start(){
        Speed = speed;
        StartCoroutine (autorunleft());
    }

    // Update is called once per frame
    void Update(){
        Vector3 temp = transform.position;
        Vector3 Vspeed = new Vector3(Speed, 0, 0);
        transform.position = temp + Vspeed*Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("Player")){
              
        }
    }
    IEnumerator autorunright(){
        Speed =-speed;
        transform.localScale = new Vector3(-1,1,0);
		yield return new WaitForSeconds (time);
        StartCoroutine (autorunleft());
	}
    IEnumerator autorunleft(){
        Speed = speed;
        transform.localScale = new Vector3(1,1,0);
        yield return new WaitForSeconds (time);
        StartCoroutine (autorunright());
	}
}

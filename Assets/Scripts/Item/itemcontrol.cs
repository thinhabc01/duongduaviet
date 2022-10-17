using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcontrol : MonoBehaviour
{
    public bool check = false; 
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Collider>().isTrigger = true;
        //StartCoroutine (autodestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        // if (other.gameObject.tag.Equals("play1")){
        //     if(other.gameObject.GetComponent<ItemPrayer>().item =="Empty"){
        //         Destroy(gameObject);
        //     }   
        // }
    }
    IEnumerator autodestroy(){
		yield return new WaitForSeconds (30);
        Destroy(gameObject);
	}
}

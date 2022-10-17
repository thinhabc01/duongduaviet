using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {
    void Start () {
		StartCoroutine (Spawner ());
	}
	
	IEnumerator Spawner(){
		yield return new WaitForSeconds (3);
        Destroy(gameObject);
	}
}

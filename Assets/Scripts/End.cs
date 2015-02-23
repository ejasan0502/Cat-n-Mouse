using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {
    private GameObject player;

    void Awake(){
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other){
        if ( other.gameObject == player ){
            GameManager.instance.Victory();
        }
    }
}

using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
    public Transform block;
    public Transform moveObj;

    private Vector3 origPos;

    void Start(){
        origPos = moveObj.transform.position;
    }

    void Update(){
        if ( Vector3.Distance(transform.position,block.transform.position) <= 0.5f ){
            if ( moveObj.transform.position.y + moveObj.renderer.bounds.size.y/2.0f > 0 )  
                moveObj.transform.position += new Vector3(0,-0.5f*Time.deltaTime,0);
        } else if ( moveObj.transform.position != origPos ){
            moveObj.transform.position += new Vector3(0,0.5f*Time.deltaTime,0);
            if ( Vector3.Distance(moveObj.transform.position,origPos) <= 0.5f ){
                moveObj.transform.position = origPos;
            }
        }
    }
}

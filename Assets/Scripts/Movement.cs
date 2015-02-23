using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float speed = 50f;

    void Update(){
        float x = Input.GetAxis("Horizontal")*speed;
        float y = Input.GetAxis("Vertical")*speed;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(new Vector3(x,0,y),ForceMode.Impulse);
    }
}

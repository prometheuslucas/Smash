using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour {
    private Rigidbody rigid;
    public float movementForce= 1;
    ////Happens before it´s created, ussually about relationships
    //void Awake()
    //{


    //}

	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame, happens faster if the computer can handel more frames, sacrifes them first when not enough processing power
	void Update () {
		
	}
    void LateUpdate()
    {

    }
    //Update passiert bei jeden Computer gleich, pro Secunde
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.W))
        //    rigid.AddForce(Vector3.forward * movementForce, ForceMode.Impulse);
        //if (Input.GetKey(KeyCode.S))
        //    rigid.AddForce(Vector3.back * movementForce, ForceMode.Impulse);
        //if (Input.GetKey(KeyCode.D))
        //    rigid.AddForce(Vector3.right * movementForce, ForceMode.Impulse);
        //if (Input.GetKey(KeyCode.A))
        //    rigid.AddForce(Vector3.left * movementForce, ForceMode.Impulse);
        
        rigid.AddForce(Vector3.up * movementForce*Input.GetAxis("Jump"), ForceMode.Impulse);
        rigid.AddForce(Vector3.down * movementForce*Input.GetAxis("Fire1"), ForceMode.Impulse);

        //Camera directions is downward diagonal so we need to make it horizontal movement forward
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0;
        camForward.Normalize();
        rigid.AddForce(Camera.main.transform.right * movementForce * Input.GetAxis("Horizontal"), ForceMode.Impulse);

        
        rigid.AddForce(Camera.main.transform.forward * movementForce * Input.GetAxis("Vertical"), ForceMode.Impulse);
    }
}
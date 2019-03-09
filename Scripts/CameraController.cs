using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    //Assign to the player
    public Transform target;
    public float offsetX;
	public float offsetY;
    void Update(){
        transform.position = new Vector3(target.position.x + offsetX, offsetY,-1);
    }
}
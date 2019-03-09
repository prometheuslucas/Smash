using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patriarchy: MonoBehaviour {
	public float hp;
	void start(){

	}

	void Update(){
		if(hp<=0){
			Destroy(gameObject);
		}
	}

}

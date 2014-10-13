using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

	public string targetTag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.gameObject.tag == targetTag) {
			Debug.Log("Oi " + targetTag);
			rigidbody2D.velocity = Vector3.zero;
			collisionInfo.collider.gameObject.rigidbody2D.velocity = Vector3.zero;
		}
	}

}

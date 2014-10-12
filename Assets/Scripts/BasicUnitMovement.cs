using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour
{
	#region Public parameters
	
	public float speed = 10f;
	
	#endregion
	
	#region Private attributes
	
	#endregion
	
	
	// Use this for initialization
	void Start()
	{
		transform.position = new Vector3(0, 0, 0);
		rigidbody2D.velocity = Vector2.right.normalized * speed;
	}
	
}

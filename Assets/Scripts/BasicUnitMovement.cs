using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour
{
	#region Public parameters
	
	public float speed = 10f;
    public Vector2 direction;
	
	#endregion
	
	#region Private attributes
	
	#endregion
	
	
	// Use this for initialization
	void Start()
	{
		rigidbody2D.velocity = direction.normalized * speed;
	}
	
}

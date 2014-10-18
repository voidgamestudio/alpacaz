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
		applyMovement();
	}

	public void applyMovement()
	{
		rigidbody2D.velocity = direction.normalized * speed;
	}
}

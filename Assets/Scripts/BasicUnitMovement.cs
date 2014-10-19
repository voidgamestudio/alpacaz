using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour
{
	#region Public parameters
	
	public float speed = 10f;

	
	#endregion
	
	#region Private attributes
	
    private Vector2 direction;
	
    #endregion
	
	
	// Use this for initialization
	void Start()
	{
	}

	public void applyMovement()
	{
		rigidbody2D.velocity = direction.normalized * speed;
	}

    public void setDirection(Vector2 direction) {
        this.direction = direction;
        applyMovement();
    }
}

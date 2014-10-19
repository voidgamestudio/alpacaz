using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {
    
    #region Public Attributes

    public float hp = 100;

    #endregion

    
    #region Private attributes

    private string targetTag;
    private UnitState state;
    private GameObject currentTarget;

    #endregion



	// Use this for initialization
	void Start () {
	
	}

    public void initialize(Vector2 direction, string myTag, string targetTag)
    {
        BasicUnitMovement unitMovement = gameObject.GetComponent<BasicUnitMovement>();
        unitMovement.setDirection(direction);
        this.targetTag = targetTag;
        gameObject.tag = myTag;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (state == UnitState.Attacking) {
			CauseDamage(currentTarget);
			CheckDeath(currentTarget);
		}
	}

	void CauseDamage(GameObject target) {
		float damage = Random.Range (0.0F, 10.0F);
		UnitController targetController = (UnitController) target.GetComponent<UnitController>();
		targetController.hp -= damage;
		Debug.Log (targetTag + " received a damage of " + damage + ". Current HP: " + targetController.hp);
	}

	void CheckDeath(GameObject target) {
		UnitController targetController = (UnitController) target.GetComponent<UnitController>();
		if (targetController.hp <= 0.0F) {
			ChangeStateToWalking();
			CleanAndDestroyTarget(target);
		}
	}

	void CleanAndDestroyTarget(GameObject target) {
		Destroy(target);
		currentTarget = null;
	}

	void ChangeStateToWalking() {
		state = UnitState.Walking;
		BasicUnitMovement basicUnitMovement = (BasicUnitMovement) this.GetComponent<BasicUnitMovement>();
		basicUnitMovement.applyMovement();
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.gameObject.tag == targetTag) {
			state = UnitState.Attacking;
			currentTarget = collisionInfo.collider.gameObject;
		}
	}
}

public enum UnitState {
	Walking,
	Attacking
}

using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {
    
    #region Public Attributes

    public Attackable attackableBehavior;

    #endregion

    
    #region Private attributes

    private string targetTag;
    private UnitState state;
    private GameObject currentTarget;

    #endregion



	// Use this for initialization
	void Start () {
        attackableBehavior = (Attackable) this.GetComponent<Attackable>();
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
			this.attackableBehavior.CauseDamage(currentTarget);
            Attackable targetAttackable = (Attackable) currentTarget.GetComponent<Attackable>();

            if (targetAttackable.CheckDeath())
            {
                ChangeStateToWalking();
                CleanAndDestroyTarget(currentTarget);
            }

		}
	}

    public void CleanAndDestroyTarget(GameObject target)
    {
        Destroy(target);
        currentTarget = null;
    }

    public bool checkDeath()
    {
        return this.attackableBehavior.CheckDeath();
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

    public void subtractHp(float damage)
    {
        this.attackableBehavior.subtractHp(damage);
    }
}

public enum UnitState {
	Walking,
	Attacking
}

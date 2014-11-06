using UnityEngine;
using System.Collections;

public class Attackable : MonoBehaviour
{

    #region Public Attributes
    
    public float hp = 100;

    #endregion

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float CauseDamage(GameObject target)
    {
        float damage = Random.Range(0.0F, 10.0F);
        Attackable targetAttackable = (Attackable)target.GetComponent<Attackable>();
        targetAttackable.subtractHp(damage);
        return damage;
    }

    public bool CheckDeath()
    {
       return this.hp <= 0;
    }

    public void subtractHp(float damage) 
    {
        this.hp -= damage; 
    }
}

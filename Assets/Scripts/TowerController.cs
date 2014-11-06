using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {

    #region Public Attributes

    public Attackable attackableBehavior;

    #endregion

	// Use this for initialization
	void Start () {
        attackableBehavior = (Attackable) this.GetComponent<Attackable>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        string winner = this.tag == "EnemyUnit" ? "Player" : "Enemy";
        Debug.Log("AND THE WINNER WAS........ " + winner);
    }
}

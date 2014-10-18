using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour
{

    public GameObject playerBase;

    
    #region private attributes

    private float offset = 0.05f;

    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateUnit(GameObject unit)
    {
        Vector3 baseSize = playerBase.renderer.bounds.size;
        Vector3 unitInitialPosition = playerBase.transform.position + new Vector3(baseSize.x + offset, baseSize.y);
        Debug.Log(unitInitialPosition);
        Instantiate(unit, unitInitialPosition, Quaternion.identity);
    }
}

using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

    public GameObject Unit;
    public GameControllerScript gc;

    #region Private attributes

    private int buttonSize = 64;

    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Clicado!");
        gc.CreateUnit(Unit);
    }
}

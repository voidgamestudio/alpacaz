﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public GameObject playerBase;
    public Vector2 playerDirection;
    public string myTag;
    public string targetTag;
	public float resource;
	public float deltaResource = 10;
    
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
		// 
		resource += Time.deltaTime * deltaResource;
		GUIText txt = GameObject.Find("resourceText").guiText;
		txt.text = ((int)resource).ToString();
		Debug.Log (resource);
    }

    public void CreateUnit(GameObject unit)
    {
        Vector3 baseSize = playerBase.renderer.bounds.size;
        Vector3 unitInitialPosition = playerBase.transform.position + new Vector3(baseSize.x + offset, baseSize.y);
        Debug.Log(unitInitialPosition);
        GameObject gameUnit = (GameObject) Instantiate(unit, unitInitialPosition, Quaternion.identity);
        UnitController unitController = gameUnit.GetComponent<UnitController>();
        unitController.initialize(playerDirection, myTag, targetTag);
    }
}

using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

    public GameObject Unit;
    public GameControllerScript GameController;
    public float Cooldown = 1f;

    #region Private attributes

    private int buttonSize = 64;
    private float currentCooldown = 0;
    private bool onCooldown = false;

    #endregion

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (onCooldown)
        {
            currentCooldown -= Time.deltaTime;
            renderer.material.SetFloat("_Cutoff", currentCooldown / Cooldown);
            if (currentCooldown <= 0)
            {
                StopCooldown();
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicado!");
        if (!onCooldown)
        {
            GameController.CreateUnit(Unit);
            Debug.Log("Ação realizada");
            StartCooldown();
        }
    }

    private void StartCooldown()
    {
        onCooldown = true;
        currentCooldown = Cooldown;
    }

    private void StopCooldown()
    {
        onCooldown = false;
        currentCooldown = 0;
    }
}

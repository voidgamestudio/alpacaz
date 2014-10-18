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
            Transform cooldownForeground = transform.GetChild(0);
            Vector3 currentScale = cooldownForeground.transform.localScale;
            setMaterialAlpha(cooldownForeground.GetChild(0), 0.5f);
            cooldownForeground.transform.localScale = new Vector3(currentScale.x, currentCooldown / Cooldown, currentScale.z);
            if (currentCooldown <= 0)
            {
                StopCooldown();
            }
        }
    }

    private static void setMaterialAlpha(Transform transf, float val)
    {
        Color c = transf.renderer.material.color;
        c.a = val;
        transf.renderer.material.color = c;
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

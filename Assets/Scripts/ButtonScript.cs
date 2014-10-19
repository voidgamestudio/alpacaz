using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

    public GameObject Unit;
    public PlayerScript GameController;
    public float Cooldown = 1f;

    #region Private attributes

    private int buttonSize = 64;
    private float currentCooldown = 0;
    private bool onCooldown = false;
    private Transform cooldownForeground;

    #endregion

    // Use this for initialization
    void Start()
    {
        cooldownForeground = transform.GetChild(0);
        setMaterialAlpha(cooldownForeground.GetChild(0), 0.5f);
    }

    void Update()
    {
        if (onCooldown)
        {
            currentCooldown -= Time.deltaTime;
            Vector3 currentScale = cooldownForeground.transform.localScale;
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
        if (!onCooldown)
        {
            GameController.CreateUnit(Unit);
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

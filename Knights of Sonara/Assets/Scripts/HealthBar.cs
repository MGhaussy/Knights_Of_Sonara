using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public int maxHealth = 20;
    private int currentHealth;
    private bool isSubtractingHealth = false;

    public bool IsSubtractingHealth
    {
        get { return isSubtractingHealth; }
        set { isSubtractingHealth = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        currentHealth = maxHealth;
        updateHealthSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateHealthSize()
    {
        bar.localScale = new Vector3(normaliseHealth(), 1.0f);
    }

    private float normaliseHealth()
    {
        float normalisedSize = (100.0f * currentHealth) / maxHealth;
        return normalisedSize / 100.0f;
    }

    public void subtractHealth(int howMuchHealth)
    {
        if (currentHealth > 0 && !isSubtractingHealth)
        {
            currentHealth -= howMuchHealth;
            updateHealthSize();
        }
    }
}

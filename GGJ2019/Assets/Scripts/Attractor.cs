using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    const float G = 667.4f;

    public List<Attractor> Attractors;

    public Rigidbody rb;

    void FixedUpdate()
    {
        bool found = false;
        Attractor[] tmp = GameObject.FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in tmp)
        {
            foreach (Attractor attractor_1 in Attractors) {
                if (attractor == attractor_1) {
                    found = true;
                    break;
                }
            }
            if(!found)
            {
                Attractors.Add(attractor);
            }
            found = false;
        }

        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }

}
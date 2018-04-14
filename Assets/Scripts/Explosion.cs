using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float m_Radius = 1;
    public float m_Force = 500;
    private float m_UpwardsModifier = 0;

    private void Start()
    {
        Invoke("Explode", 2);
    }

    private void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, m_Radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(m_Force, explosionPos, m_Radius, m_UpwardsModifier);
        }
        Destroy(gameObject);
    }
}

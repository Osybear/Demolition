using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private float m_Radius = 2.0F;
    private float m_Force = 500.0F;
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

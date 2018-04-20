using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public Camera m_MainCamera;
    public GameObject m_ExplosivePrefab;
    public float m_Radius = 1;
    public float m_Force = 500;

    private void Start()
    {
        m_ExplosivePrefab = Instantiate(m_ExplosivePrefab);
        m_ExplosivePrefab.GetComponent<Explosion>().enabled = false;
        m_ExplosivePrefab.GetComponent<MeshRenderer>().material.color -= new Color(0, 0, 0, .5f);
    }

    private void Update()
    {
        if (Instructions.m_Completed == true)
        {
            PlaceExplosive();
            ExplosiveReference();
            IncreaseExplosiveSize();
        }
    }

    private void PlaceExplosive()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 Position = hit.point;
                GameObject prefab = Instantiate(m_ExplosivePrefab, Position, Quaternion.identity);
                prefab.GetComponent<Explosion>().enabled = true;
                prefab.GetComponent<Explosion>().m_Radius = m_Radius;
                prefab.GetComponent<Explosion>().m_Force = m_Force;
                prefab.GetComponent<MeshRenderer>().material.color += new Color(0, 0, 0, .5f);
                prefab.transform.SetParent(hit.transform);
            }
        }
    }

    private void ExplosiveReference()
    {
        RaycastHit hit;
        Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 Position = hit.point;
            m_ExplosivePrefab.transform.position = hit.point;
        }
    }

    private void IncreaseExplosiveSize()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            m_Radius -= 0.1f;
            m_Force -= 50;
        }

        if (Input.GetKey(KeyCode.E))
        {
            m_Radius += 0.1f;
            m_Force += 50;
        }

        m_ExplosivePrefab.transform.localScale = new Vector3(m_Radius, m_Radius, m_Radius);
        m_Radius = Mathf.Clamp(m_Radius, 1, float.MaxValue);
        m_Force = Mathf.Clamp(m_Force, 50, float.MaxValue);
    }
}

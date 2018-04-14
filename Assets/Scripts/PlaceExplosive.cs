using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceExplosive : MonoBehaviour {

    public Camera m_MainCamera;
    public GameObject m_ExplosivePrefab;
    public float m_Radius = 1;
    public float m_Force = 500;

    private Vector3 m_MousePosRef;
    private bool m_M2Dragged = false;

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

            if (true)
            {
                RaycastHit hit;
                Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);

                if (m_M2Dragged == false && Physics.Raycast(ray, out hit))
                {
                    Vector3 Position = hit.point;
                    m_ExplosivePrefab.transform.position = hit.point;
                }
            }

            if (Input.GetMouseButton(1))
            {
                m_M2Dragged = true;
                if (Input.mousePosition.x > m_MousePosRef.x)
                {
                    m_Radius += 0.25f;
                    m_Force += 100;
                    m_ExplosivePrefab.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
                }
                if (Input.mousePosition.x < m_MousePosRef.x)
                {
                    m_Radius -= 0.25f;
                    m_Force -= 100;
                    m_ExplosivePrefab.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
                }

                m_Radius = Mathf.Clamp(m_Radius, 2, float.MaxValue);
                m_Force = Mathf.Clamp(m_Force, 500, float.MaxValue);

                var x = Mathf.Clamp(m_ExplosivePrefab.transform.localScale.x, .5f, float.MaxValue);
                m_ExplosivePrefab.transform.localScale = new Vector3(x, x, x);
            }
            else
            {
                m_M2Dragged = false;
            }
        }
    }

    private void LateUpdate()
    {
        m_MousePosRef = Input.mousePosition;
    }
}

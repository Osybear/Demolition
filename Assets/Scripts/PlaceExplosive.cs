using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceExplosive : MonoBehaviour {

    public GameObject m_ExplosivePrefab; // The explosive in the prefabs folder
    public Camera m_MainCamera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 Position = hit.point;
                GameObject prefab = Instantiate(m_ExplosivePrefab, Position, Quaternion.identity);
                prefab.transform.SetParent(hit.transform);
            }
        }
    }
}

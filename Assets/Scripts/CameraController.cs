using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour {

    public GameObject m_MainCamera;

    private float m_XRot; // Rotation x for this gameobject
    private float m_YRot; // Rotation y for this gameobject
    private float m_ZPos; // Position z for this gameobject

    private float m_XRotMin = -24; // Max rotation on the x axis
    private float m_XRotMax = 60; // Minimum rotation on the x axis

    private float m_RotateSpeed = 1;
    private float m_ScrollSpeed = 5;

    private void Start()
    {
        m_ZPos = m_MainCamera.transform.localPosition.z;
    }

    void Update () {
        HandleRotationMovement();
    }

    private void HandleRotationMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_YRot += 1 * m_RotateSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_YRot += -1 * m_RotateSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            m_XRot += 1 * m_RotateSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_XRot += -1 * m_RotateSpeed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
        {
            m_ZPos += Input.GetAxis("Mouse ScrollWheel") * m_ScrollSpeed;
        }

        m_XRot = Mathf.Clamp(m_XRot, m_XRotMin, m_XRotMax);

        Quaternion Rotation = Quaternion.Euler(m_XRot, m_YRot, 0f);

        Vector3 Position = new Vector3(0, 0, m_ZPos);

        transform.localRotation = Rotation;
        m_MainCamera.transform.localPosition = Position;
    }
}

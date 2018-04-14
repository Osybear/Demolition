using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

    public GameObject Holder;

    public Image m_WKey;
    public Image m_RKey;
    public Image m_AKey;
    public Image m_SKey;
    public Image m_DKey;
    public Image m_M1Key;
    public Image m_M2Key;
    public Image m_MSWKey;

    private bool m_WClear = false;
    private bool m_RClear = false;
    private bool m_AClear = false;
    private bool m_SClear = false;
    private bool m_DClear = false;
    private bool m_M1Clear = false;
    private bool m_M2Clear = false;
    private bool m_MSWClear = false;

    private Color m_Clear = Color.red;

    public static bool m_Completed;

    private void Awake()
    {
        m_Completed = true;
        m_Clear = Color.green;
    }

    private void Update()
    {
        if (Focus.m_Focused == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                m_WKey.color = m_Clear;
                m_WClear = true;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                m_RKey.color = m_Clear;
                m_RClear = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                m_AKey.color = m_Clear;
                m_AClear = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                m_SKey.color = m_Clear;
                m_SClear = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                m_DKey.color = m_Clear;
                m_DClear = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                m_M1Key.color = m_Clear;
                m_M1Clear = true;
            }
            if (Input.GetMouseButton(1))
            {
                m_M2Key.color = m_Clear;
                m_M2Clear = true;
            }
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                m_MSWKey.color = m_Clear - (new Color(0, .15f, 0, 0));
                m_MSWClear = true;
            }

            if (m_WClear && m_RClear && m_AClear && m_SClear && m_DClear && m_M1Clear && m_M2Clear && m_MSWClear)
            {
                StartCoroutine(DelayComplete());
            }
        }
    }

    private IEnumerator DelayComplete()
    {
        yield return new WaitForSeconds(.5f);
        Holder.SetActive(false);
        m_Completed = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

    public GameObject m_Holder;
    public static bool m_Completed;

    private void Awake()
    {
        m_Completed = false;    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            m_Holder.SetActive(true);
            m_Completed = false;
        }

    }

    public void HideInstructions()
    {
        m_Completed = true;
        m_Holder.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

    public GameObject m_Help;
    public GameObject m_Controls;
    public GameObject m_Goal;
    public static bool m_Completed;

    private void Awake()
    {
        m_Help.SetActive(false);
        m_Controls.SetActive(false);
    }

    public void Continue()
    {
        m_Goal.SetActive(false);
        m_Help.SetActive(true);
    }

    public void Help()
    {
        m_Controls.SetActive(!m_Controls.activeInHierarchy);
    }
}

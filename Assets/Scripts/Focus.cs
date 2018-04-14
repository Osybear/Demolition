using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour {

    public GameObject m_Holder;
    public static bool m_Focused;

    private void Awake()
    {
        m_Holder.SetActive(false);
    }

    private void Update()
    {
        if (Application.isFocused == false)
        {
            m_Focused = false;
            m_Holder.SetActive(true);
        }

        if(Application.isFocused == true)
        {
            m_Focused = true;
            m_Holder.SetActive(false);
        }
    }
}

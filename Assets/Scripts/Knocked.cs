using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knocked : MonoBehaviour {

    private bool m_Knocked = false;

	void Update () {
        if (m_Knocked == false)
        {
            if (transform.position.x >= 5 || transform.position.x <= -5)
            {
                Score.m_ScoreAmount++;
                m_Knocked = true;
            }else if (transform.position.z >= 5 || transform.position.z <= -5)
            {
                Score.m_ScoreAmount++;
                m_Knocked = true;
            }
        }
	}
}

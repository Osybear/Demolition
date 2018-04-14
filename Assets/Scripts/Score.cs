using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    public Text m_ScoreText;
    public static int m_ScoreAmount;

    private void Awake()
    {
        m_ScoreAmount = 0;    
    }

    private void Update()
    {
        m_ScoreText.text = m_ScoreAmount + "/99";
    }

}

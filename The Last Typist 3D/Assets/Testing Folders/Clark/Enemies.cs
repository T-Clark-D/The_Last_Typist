using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : Targetable
{
    public Rigidbody m_RB;
    public GameObject m_player;
    public GameObject m_enemyTextPrefab;
    public float m_speed;

    public GameObject anchoredText;

    public void Initialize()
    {
        anchor = transform.GetChild(0);
        m_RB = GetComponent<Rigidbody>();
    }

    public void InitializeTextBoxWithLength(int length)
    {
        //instantiates the enemy text prefab and sets the parent to the canvas
        anchoredText = Instantiate(m_enemyTextPrefab, FindObjectOfType<Canvas>().transform);
        //sets the anchor on the prefap to that of the anchor of the zombie
        anchoredText.GetComponent<EnemyTextBehavior>().SetAnchor(anchor.gameObject);
        //Will return word of set length
        anchoredText.GetComponent<Text>().text = RandomWordOfLength(length);
    }

    private string RandomWordOfLength(int length)
    {
        targetWord = "tempword" + length.ToString();
        return targetWord;
    }

    public void Death()
    {
        Destroy(anchoredText);
        //this will need to be changed to going limp so that the dead targets can be targetted in resource collection mode
        Destroy(gameObject);
    }

    public void TargetedText(int textLength)
    {
        Debug.Log("we in targetd text");
        if(textLength == 0)
        {
            anchoredText.GetComponent<Text>().text = "<color=white>" + targetWord + "</color>";
        }
        else
        {
            anchoredText.GetComponent<Text>().text = "<color=red>" + targetWord.Substring(0, textLength) + "</color>" + targetWord.Substring(textLength, targetWord.Length - textLength);
        }
    }
}

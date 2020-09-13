using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillName : MonoBehaviour
{
    public int index;

    void Start()
    {
        gameObject.GetComponent<Text>().text = StaticClass.SkillNameList[index];

        if (StaticClass.SkillAcquired[index])
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}

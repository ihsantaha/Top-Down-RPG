using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillValue : MonoBehaviour
{
    public int index;

    void Start()
    {
        gameObject.GetComponent<Text>().text = StaticClass.SkillValueList[index];

        if (StaticClass.SkillAcquired[index])
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}

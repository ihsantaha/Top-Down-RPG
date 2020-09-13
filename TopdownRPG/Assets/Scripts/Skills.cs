using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public GameObject skills;

    void Awake()
    {
        // This code should be sent to the setup section
        StaticClass.SkillAcquired = new bool[5];
        StaticClass.SkillNameList = new string[5];
        StaticClass.SkillValueList = new string[5];

        StaticClass.SkillAcquired[0] = true;
        StaticClass.SkillAcquired[1] = true;
        StaticClass.SkillAcquired[2] = true;
        StaticClass.SkillAcquired[3] = false;
        StaticClass.SkillAcquired[4] = false;

        StaticClass.SkillNameList[0] = "Alpha Wave";
        StaticClass.SkillNameList[1] = "Osmosis";
        StaticClass.SkillNameList[2] = "Ignite";
        StaticClass.SkillNameList[3] = "Electric Pulse";
        StaticClass.SkillNameList[4] = "Destructive Root";

        StaticClass.SkillValueList[0] = "A sonic blast that penetrates through enemies at a cellular level, leaving them weakened.";
        StaticClass.SkillValueList[1] = "Absorb an enemy's stats and use it against them";
        StaticClass.SkillValueList[2] = "Scorch miltiple enemies with a fiery flame";
        StaticClass.SkillValueList[3] = "Send shockwaves consecutively into an emey's body, dealing multiple electrifying hits";
        StaticClass.SkillValueList[4] = "Incapacitate your enemy with prenetrating thorns risen from the earth";
        // ----------------------------------------------

        skills = GameObject.FindGameObjectWithTag("Skills");
    }

    public void ViewSkills()
    {
        skills.SetActive(true);
    }

    public void DisableViewSkills()
    {
        skills.SetActive(false);
    }

    public void SetActiveSubMenu()
    {
        StaticClass.statsSelected = false;
        StaticClass.skillsSelected = true;
        StaticClass.invntrySelected = false;
    }
}
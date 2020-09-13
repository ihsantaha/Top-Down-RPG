using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public GameObject stats;
    public int health, mana, strength, defense;
    public string special;

    void Start()
    {
        health   = StaticClass.Health;
        mana     = StaticClass.Mana;
        strength = StaticClass.Strength;
        defense  = StaticClass.Defense;
        special  = StaticClass.Special;

        stats = GameObject.FindGameObjectWithTag("Stats");
    }

    public void ViewStats()
    {
        print(stats.activeSelf);
        stats.SetActive(true);
    }

    public void DisableViewStats()
    {
        stats.SetActive(false);
    }

    public void SetActiveSubMenu()
    {
        StaticClass.statsSelected = true;
        StaticClass.skillsSelected = false;
        StaticClass.invntrySelected = false;
    }
}

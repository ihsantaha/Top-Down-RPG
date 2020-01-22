using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog State")]
public class DynamicText : ScriptableObject
{
    [TextArea(10, 15)] [SerializeField] public string dialogText;
    [SerializeField] public DynamicText[] nextDynamicTexts;

    public string GetDialog()
    {
        return dialogText;
    }

    public DynamicText[] GetNextDynamicTexts()
    {
        return nextDynamicTexts;
    }

}

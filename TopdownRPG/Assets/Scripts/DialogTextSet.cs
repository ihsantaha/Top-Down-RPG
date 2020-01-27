using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog Text Set")]
public class DialogTextSet : ScriptableObject
{
    [TextArea(10, 15)] [SerializeField] public string dialogText;
    [SerializeField] public bool isDecisionPoint, isEndPoint;
    [SerializeField] public DialogTextSet[] dialogTextSetList;


    public void SetDialogInfo(string str)
    {
        dialogText = str;
    }

    public void SetDialogInfo(string str, bool dec)
    {
        dialogText = str;
        isDecisionPoint = dec;
    }

    public void SetDialogInfo(string str, bool dec, bool end)
    {
        dialogText = str;
        isDecisionPoint = dec;
        isEndPoint = end;
    }

    public string GetDialogTxt()
    {
        return dialogText;
    }

    public DialogTextSet[] GetNextDialogTextSetList()
    {
        return dialogTextSetList;
    }
}

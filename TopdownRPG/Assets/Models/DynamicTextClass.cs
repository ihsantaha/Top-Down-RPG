using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTextClass
{
    public static DynamicText[] nextDynamicTexts = new DynamicText[5];

    public static void SetDialogs()
    {
        nextDynamicTexts[0].dialogText = "";
        nextDynamicTexts[1].dialogText = "Hello, I am a sample conversational dialog. Please press C to continue to the next sentence.";
        nextDynamicTexts[2].dialogText = "This is the meat of the conversation.";
        nextDynamicTexts[3].dialogText = "That's it. Press C again to end this dialog. Have a nice day!";
        nextDynamicTexts[4].dialogText = "Sleep? Y/N";

        nextDynamicTexts[0].nextDynamicTexts = new DynamicText[3];
        nextDynamicTexts[0].nextDynamicTexts[0] = nextDynamicTexts[1];
        nextDynamicTexts[0].nextDynamicTexts[1] = nextDynamicTexts[2];
        nextDynamicTexts[0].nextDynamicTexts[2] = nextDynamicTexts[3];
        
        nextDynamicTexts[1].nextDynamicTexts = new DynamicText[3];
        nextDynamicTexts[1].nextDynamicTexts[0] = nextDynamicTexts[2];
        nextDynamicTexts[1].nextDynamicTexts[1] = nextDynamicTexts[3];
        nextDynamicTexts[1].nextDynamicTexts[2] = nextDynamicTexts[0];

        nextDynamicTexts[2].nextDynamicTexts = new DynamicText[3];
        nextDynamicTexts[2].nextDynamicTexts[0] = nextDynamicTexts[3];
        nextDynamicTexts[2].nextDynamicTexts[1] = nextDynamicTexts[0];
        nextDynamicTexts[2].nextDynamicTexts[2] = nextDynamicTexts[1];
        
        nextDynamicTexts[3].nextDynamicTexts = new DynamicText[3];
        nextDynamicTexts[3].nextDynamicTexts[0] = nextDynamicTexts[0];
        nextDynamicTexts[3].nextDynamicTexts[1] = nextDynamicTexts[1];
        nextDynamicTexts[3].nextDynamicTexts[2] = nextDynamicTexts[2];
    } 
}

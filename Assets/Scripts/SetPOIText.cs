using System;
using TMPro;
using UnityEngine;

public class SetPOIText : MonoBehaviour
{
    public TextMeshProUGUI POIText;
    private string[] psycheData = { 
        "THis is a test?",
        "This is another thing I wanted to test"
    };
    
    public void settingTxt(int i)
    {
        POIText.text = psycheData[i];
        /*
        try
        {
            POIText.text = psycheData[i];
        }
        catch (IndexOutOfRangeException e)
        {
            POIText.text = "Data for this POI does NOT exist";
        }*/
    }
}

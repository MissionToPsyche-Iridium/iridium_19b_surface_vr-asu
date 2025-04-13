using System;
using TMPro;
using UnityEngine;

public class SetPOIText : MonoBehaviour
{
    public TextMeshProUGUI POIText;
    private string[] psycheData = {
        "Psyche has an irregular shape, appearing more as an egg than a sphere. One of the features that contributes to Psyche's appearance are the many craters along its surface. The leading theory for why Psyche has many craters on its surface has to do with its location in the Asteroid Belt. Scientists believe that, during its formation, Psyche was impacted by other asteroids and debris, stripping the outer layer and leading to its irregular shape.",
        "One of Psyche's unique traits is its composition. Unlike most asteroids, Psyche is estimated to have 30-60% of its volume made of metal, of which a majority is Nickel and Iron. In conjunction with its location in the asteroid belt, Psyche is theorized to be a planetesimal, the building block of planets. This is the major reason as to why scientists are interested in studying Psyche: the results from this expedition could give us insights into the formation of planets and the Solar System.",
        "The blurb about Psyche(default text?)"
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

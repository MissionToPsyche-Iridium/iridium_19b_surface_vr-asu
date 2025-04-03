using UnityEngine;
using TMPro;

public class OpeningTextManager : MonoBehaviour
{
    public TextMeshProUGUI openingText; //text gameobj
    public GameObject psycheBadge; //psyche badge game obj

    void Start()
    {
        if (psycheBadge != null)
        {
            psycheBadge.SetActive(true);
        }
        Debug.Log("OpeningTextManager called");
        openingText.text = "Welcome to Psyche!";

        Invoke("ShowSecondText", 3f);
        Invoke("ShowThirdText", 6f); 
        Invoke("HideText", 9f); // hide text after 9 seconds TOTAL
    }

    void ShowSecondText()
    {
        openingText.text = "Fall 2024 - Spring 2025 Capstone project";
    }

    void ShowThirdText()
    {
        openingText.text = "Quinn Cage, Trevor Huss, Sammy Belskus, Andrew Tan, Aidan Dubel";
    }

    void HideText()
    {
        openingText.gameObject.SetActive(false);
        if (psycheBadge != null)
        {
            psycheBadge.SetActive(false); // hide the psyche icon
        }
    }
}

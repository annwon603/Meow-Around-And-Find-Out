
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VRC.SDKBase;
using VRC.Udon;

public class QuestManager : UdonSharpBehaviour
{
    //the Gameobject of the text we're displaying
    public GameObject textmeshpro_objective;

    //the list of text to choose from 
    public GameObject[] listOfQuest;

    // public Button button;
    // Button btn;


    GameObject theChosenOne;
    //the text we're accessing from textmeshpro_objective
    TextMeshProUGUI textmeshpro_objective_text;
    TextMeshProUGUI chosentext;

    int numOfClicks = 0;

    void Start()
    {
        textmeshpro_objective_text = textmeshpro_objective.GetComponent<TextMeshProUGUI>();
        // btn = button.GetComponent<Button>();
    }

    public void Interact(){
        Debug.Log("Interact ran");
        Debug.Log(numOfClicks);
        Increase();
    }

    void Increase()
    {

        if(numOfClicks < 3){
            numOfClicks++;
        }else{
            numOfClicks = 0;
        }
        
    }

    void Update()
    {   

        theChosenOne = listOfQuest[numOfClicks];
        
        chosentext = theChosenOne.GetComponent<TextMeshProUGUI>();
        textmeshpro_objective_text.text = chosentext.text;

    }
}

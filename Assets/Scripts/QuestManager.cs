
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



    GameObject theChosenOne;
    //the text we're accessing from textmeshpro_objective
    TextMeshProUGUI textmeshpro_objective_text;
    TextMeshProUGUI chosentext;

    public int alreadySet;
    public int pointer = 0;

    public int numOfQuestComplete = 0;

    void Start()
    {

        textmeshpro_objective_text = textmeshpro_objective.GetComponent<TextMeshProUGUI>();

    }

    public void setPointer(int setter)
    {
        pointer = setter;
        alreadySet = setter;
    
    }

    public int alreadysetter(){
        return alreadySet;
    }



    public void Increase()
    {
        numOfQuestComplete++;
    }

    public void UpdatePointer()
    {
      
        if(pointer < 4){
            pointer ++;
        }else{
            pointer = 0;
        }

    }

    void Update()
    {   
        if(numOfQuestComplete < 4){
            theChosenOne = listOfQuest[pointer];
        
            chosentext = theChosenOne.GetComponent<TextMeshProUGUI>();
            textmeshpro_objective_text.text = chosentext.text;

        }else{

            theChosenOne = listOfQuest[4];
            chosentext = theChosenOne.GetComponent<TextMeshProUGUI>();
            textmeshpro_objective_text.text = chosentext.text;

        } 

    }
}

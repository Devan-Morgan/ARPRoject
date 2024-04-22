using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxManager : MonoBehaviour
{
    private string correctGemOrder = "BlueRedGreen";
    private string enteredGemOrder = "";
    
    private int amountOfGems = 3;
    private int currentGem = 0;
    
    public Animator boxAnimator;

    public Gem[] gemsInScene;

    public UnityEvent gameIsWon;
    

    public void GemSelect(Gem currentSelectedGem)
    {
        // add the gem to the enteredGemOrder string
        enteredGemOrder += currentSelectedGem.gemColorName;
        
        // increase the currentGem count
        currentGem += 1;
        
        //change the gem emission
        currentSelectedGem.ChangeEmission(true);
        
        //if currentGem == amountOfGems, check if the enteredGemOrder string is equal to the correctGemOrder string
        if (currentGem == amountOfGems)
        {
            CompareGemOrder();
        }
        
        // if it is, open the box
    }

     void CompareGemOrder()
    {
        if (enteredGemOrder == correctGemOrder)
        {
            CompleteGame();
        }
        else
        {
            ResetGame();
        }
    }

     void CompleteGame()
    {
        gameIsWon.Invoke();
    }

     void ResetGame()
    {
        currentGem = 0;
        enteredGemOrder = "";
        
        //reset the gem emission
        foreach (var gem in gemsInScene)
        {
            gem.ChangeEmission(false);
        }
        
    }
}

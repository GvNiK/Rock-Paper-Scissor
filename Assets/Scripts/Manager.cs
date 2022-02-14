using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI result;

    [Header ("Buttons")]
    [SerializeField] private Button rock, paper, scissor;

    private ImageUpdate imageUpdate;
    private AudioSource sound;

    private bool roundComplete = false;
    public string[] choices;

    [Header ("Images")]
    [SerializeField] private Animator animPlayer;
    [SerializeField] private Animator animAI;

    private void Start() 
    {
        imageUpdate = this.GetComponent<ImageUpdate>();    
        sound = GetComponent<AudioSource>();
    }

    public void Play(string myTurn) 
    {
        StartCoroutine(StartTime(myTurn));
        Reset();
    }

    private IEnumerator StartTime(string myTurn)
    {
        sound.Play();
        animPlayer.SetBool("Bang", true);
        animAI.SetBool("Bang", true);
        yield return new WaitForSeconds(3.0f);
        PlayHands(myTurn);
    }

    public void PlayHands(string myChoice)
    {
        string randomChoices = choices[Random.Range(0, choices.Length)];

        imageUpdate.PlayerImageUpdate(myChoice);
        imageUpdate.AIImageUpdate(randomChoices);

        switch(randomChoices)
        {
            case "Rock" :
                switch(myChoice)
                {
                    case "Rock" :
                        result.text = "No one Wins. It's a Tie!";
                        roundComplete = true;
                        break;

                    case "Paper" :
                    result.text = "You Win! Paper covers Rock. ";
                        roundComplete = true;
                        break;    

                    case "Scissor" :
                        result.text = "You Loose! Rock destroys Scissor. ";
                        roundComplete = true;
                        break;    
                }
                break;

            case "Paper" :
                switch(myChoice)
                {
                    case "Rock" :
                        result.text = "You Loose! Paper covers Rock. ";
                        roundComplete = true;
                        break;

                    case "Paper" :
                        result.text = "No one Wins. It's a Tie!";
                        roundComplete = true;
                        break;    

                    case "Scissor" :
                        result.text = "You Win! Paper cuts Paper. ";
                        roundComplete = true;
                        break;    
                }
                break;

            case "Scissor" :
                switch(myChoice)
                {
                    case "Rock" :
                        result.text = "You Win! Rock destroys Scissor. ";
                        roundComplete = true;
                        break;

                    case "Paper" :
                        result.text = "You Loose! Paper covers the Rock. ";
                        roundComplete = true;
                        break;    

                    case "Scissor" :
                        result.text = "No one Wins. It's a Tie!";
                        roundComplete = true;
                        break;    
                }
                break;        
        }

        if(roundComplete)
        {
            animPlayer.SetBool("Bang", false);
            animAI.SetBool("Bang", false);
            //result.text = "RoundComplete";
            Debug.Log(roundComplete);
        }
    }

    private void Reset()
    {
        if(roundComplete)
        {
            imageUpdate.ResetImages();
            result.text = "";
        }
    }
   

}

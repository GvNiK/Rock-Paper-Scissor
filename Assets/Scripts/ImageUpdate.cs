using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageUpdate : MonoBehaviour
{
    [Header ("Images")]
    [SerializeField] private Image myChoice;
    [SerializeField] private Image aiChoice;


    [Header ("Extra - Images")]
    [SerializeField] private Image rockImage;
    [SerializeField] private Image paperImage;
    [SerializeField] private Image scissorImage;

    [Header ("Extra - Images")]
    [SerializeField] private Image aiRockImage; 
    [SerializeField] private Image aiPaperImage; 
    [SerializeField] private Image aiScissorImage;


    public void PlayerImageUpdate(string name)
    {
        if(name == rockImage.name)
        {
            myChoice.sprite = rockImage.sprite;
            rockImage.enabled = true;
        }

        if(name == paperImage.name)
        {
            myChoice.sprite = paperImage.sprite;
            rockImage.enabled = true;
        }

        if(name == scissorImage.name)
        {
            myChoice.sprite = scissorImage.sprite;
            rockImage.enabled = true;
        }
    }

    public void AIImageUpdate(string name)
    {
        if(name == rockImage.name)
        {
            aiChoice.sprite = aiRockImage.sprite;
            rockImage.enabled = true;
        }

        if(name == paperImage.name)
        {
            aiChoice.sprite = aiPaperImage.sprite;
            rockImage.enabled = true;
        }

        if(name == scissorImage.name)
        {
            aiChoice.sprite = aiScissorImage.sprite;
            rockImage.enabled = true;
        }
    }

    public void ResetImages()
    {
        aiChoice.sprite = aiRockImage.sprite;
        myChoice.sprite = rockImage.sprite;
    }
}
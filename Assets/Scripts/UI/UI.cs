using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //Start Menu
    public GameObject startMenu;

    //Options
    public GameObject optionsMenu;

    //Credits
    public GameObject creditsMenu;

    //hud
    public GameObject hud;
    public Image stressMeter;
    public GameObject shoppingListObject;
    private int open = 0;

    void Start()
    {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        hud.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenList();
        }
    }

    public void SubtractStressBar(float percentage)
    {
        stressMeter.fillAmount -= percentage;
    }
    public void AddStressBar(float percentage)
    {
        stressMeter.fillAmount += percentage;
    }
    private void OpenList()
    {
        if (open == 0)
        {
            shoppingListObject.SetActive(true);
            open = 1;
        }
        else
        {
            shoppingListObject.SetActive(false);
            open = 0;
        }
    }

    public void StartButton()
    {
        startMenu.SetActive(false);
        hud.SetActive(true);
    }
    public void OptionsButton()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void OptionsBackButton()
    {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void CreditsButton()
    {
        startMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void CreditsBackButton()
    {
        startMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
}

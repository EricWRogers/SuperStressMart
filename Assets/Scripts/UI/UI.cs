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
    public Slider soundSlider;

    //hud
    public GameObject hud;
    public GameObject controlPanel;
    public GameObject battery;
    public Image batteryMeter;
    public Image stressMeter;
    public GameObject shoppingListObject;
    public Toggle[] toggles;
    public Text[] texts;
    private int openList = 0;
    private int openControls = 0;
    private int playMusic = 0;
    private float controlTimer = 0f;

    //GameOver
    public GameObject gameOverPanel;
    public GameObject winPanel;

    void Start()
    {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        hud.SetActive(false);
        stressMeter.fillAmount = 0f;
        soundSlider = soundSlider.GetComponent<Slider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OpenList();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenControl();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Music();
        }
        if (controlTimer > 0)
        {
            controlTimer -= Time.deltaTime;
            if (controlTimer <= 0)
            {
                controlPanel.SetActive(false);
            }
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
        if (openList == 0)
        {
            shoppingListObject.SetActive(true);
            openList = 1;
        }
        else
        {
            shoppingListObject.SetActive(false);
            openList = 0;
        }
    }
    private void OpenControl()
    {
        if (openControls == 0)
        {
            controlPanel.SetActive(true);
            openControls = 1;
        }
        else
        {
            controlPanel.SetActive(false);
            openControls = 0;
        }
        if(controlTimer > 0f)
        {
            controlTimer = 0f;
        }
    }
    public void StartButton()
    {
        startMenu.SetActive(false);
        hud.SetActive(true);
        controlPanel.SetActive(true);
        controlTimer = 20f;
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
    public void CheckedIfPickedUp(string itemName)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (texts[i].text == itemName)
            {
                toggles[i].isOn = !toggles[i].isOn;
            }
        }
    }
    public void SoundSlider()
    {
        AudioListener.volume = soundSlider.value;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Music()
    {
        if (playMusic == 0)
        {
            battery.SetActive(true);
            playMusic = 1;
        }
        else
        {
            battery.SetActive(false);
            playMusic = 0;
        }
    }

}

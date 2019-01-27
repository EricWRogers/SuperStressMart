using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameManager GameManager;
    private AudioManager AudioManager;

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
    public Text pillsText;
    private int pills = 3;
    private int openList = 0;
    private int openControls = 0;
    private int playMusic = 0;
    private float controlTimer = 0f;
    private float pillTimer = 0f;
    private float batteryTimer = 0f;
    public float battervalue = 1f;

    //GameOver
    public GameObject gameOverPanel;
    public GameObject winPanel;

    public Image overlayPanel;
    public GameObject overLayPanel;

    public Color[] playerColors;


    void Start()
    {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        hud.SetActive(false);
        stressMeter.fillAmount = 0f;
        soundSlider = soundSlider.GetComponent<Slider>();
        GameManager = GameManager.GetComponent<GameManager>();
        AudioManager = GameManager.GetComponent<AudioManager>();
        pills = 3;
        pillsText.text = "" + pills;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenControl();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Music();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakePill();
        }
        if (controlTimer > 0)
        {
            controlTimer -= Time.deltaTime;
            if (controlTimer <= 0)
            {
                controlPanel.SetActive(false);
            }
        }
        if (AudioManager.backGroudSource.isPlaying || AudioManager.voicesSource.isPlaying)
        {
            if (AudioManager.currentVoice>0) 
            {
                overlayPanel.color = playerColors[AudioManager.currentVoice];
                overLayPanel.SetActive(true);
            }
            else
            {
                overLayPanel.SetActive(false);
            }

        }
        else
        {
            overLayPanel.SetActive(false);
        }


        stressMeter.fillAmount = GameManager.StressBar;
    }
    private void FixedUpdate()
    {
        if (pillTimer>0f)
        {
            pillTimer -= Time.deltaTime;
            GameManager.ChangeStress(-.1f);
        }
        if (AudioManager.backGroudSource.isPlaying)
        {
            battervalue -= .01f;
            batteryMeter.fillAmount = battervalue;
            GameManager.ChangeStress(-.02f);
        }
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
        AudioManager.SoundsEventTrigger(SoundEvents.StartingGame);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

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
        AudioManager.SoundsEventTrigger(SoundEvents.PassesOut);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Win()
    {
        winPanel.SetActive(true);
        AudioManager.SoundsEventTrigger(SoundEvents.Success);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Music()
    {
        if (playMusic == 0)
        {
            AudioManager.SoundsEventTrigger(SoundEvents.PhoneMusic);
            battery.SetActive(true);
            playMusic = 1;
        }
        else
        {
            battery.SetActive(false);
            playMusic = 0;
        }
    }
    public void TakePill()
    {
        pills--;
        pillsText.text = "" + pills;
        AudioManager.SoundsEventTrigger(SoundEvents.AnxietyLax);
        pillTimer = 10f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

}

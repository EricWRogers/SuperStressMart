using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEvents
{
    StartingGame,
    NPCTalking,
    NPCTalkingToEmily,
    PickingUpItem,
    HidesInBathroom,
    PathBlocked,
    AnxietyLax,
    NPCStandingBetween,
    FireAlarm,
    Success,
    PassesOut,
    ArgumentBreaksOut,
    CardDeclined,
    HighAnxiety,
    CheckingOut,
    SeeingEx,
    ShelfFalls,
    PhoneMusic,
    BackGroundMusic,
}
[System.Serializable]
public class Clips
{
    public SoundEvents sounds;
    public AudioClip audio;
    public bool hasPlayed=false;
}

public class AudioManager : MonoBehaviour
{
    public List<Clips> startingGameClips = new List<Clips>();
    public List<Clips> npcTalkingToEmilyClips = new List<Clips>();
    public List<Clips> pickingUpItemClips = new List<Clips>();
    public List<Clips> hidesInBathroomClips = new List<Clips>();
    public List<Clips> pathBlockedClips = new List<Clips>();
    public List<Clips> anxietyLaxClips = new List<Clips>();
    public List<Clips> npcStandingBetweenClips = new List<Clips>();
    public List<Clips> fireAlarmClips = new List<Clips>();
    public List<Clips> successClips = new List<Clips>();
    public List<Clips> passesOutClips = new List<Clips>();
    public List<Clips> argumentBreaksOutClips = new List<Clips>();
    public List<Clips> cardDeclinedClips = new List<Clips>();
    public List<Clips> highAnxietyClips = new List<Clips>();
    public List<Clips> checkingOutClips = new List<Clips>();
    public List<Clips> seeingExClips = new List<Clips>();
    public List<Clips> shelfFallsClips = new List<Clips>();
    public List<Clips> phoneMusicClips = new List<Clips>();
    public List<Clips> backGroundClips = new List<Clips>();

    public AudioSource backGroudSource;
    public AudioSource voicesSource;

    //public AudioClip backGroundMusic;
    private void Start()
    {
        backGroudSource = backGroudSource.GetComponent<AudioSource>();
        voicesSource = voicesSource.GetComponent<AudioSource>();
    }

    public void SoundsEventTrigger(SoundEvents soundEvents)
    {
        switch (soundEvents)
        {
            case SoundEvents.StartingGame:
                StartingGame();
                break;
            case SoundEvents.NPCTalking:
                break;
            case SoundEvents.NPCTalkingToEmily:
                NPCTalkingToEmily();
                break;
            case SoundEvents.PickingUpItem:
                PickingUpItem();
                break;
            case SoundEvents.HidesInBathroom:
                HidesInBathroom();
                break;
            case SoundEvents.PathBlocked:
                PathBlocked();
                break;
            case SoundEvents.AnxietyLax:
                AnxietyLax();
                break;
            case SoundEvents.NPCStandingBetween:
                NPCStandingBetween();
                break;
            case SoundEvents.FireAlarm:
                FireAlarm();
                break;
            case SoundEvents.Success:
                Success();
                break;
            case SoundEvents.PassesOut:
                PassesOut();
                break;
            case SoundEvents.ArgumentBreaksOut:
                ArgumentBreaksOut();
                break;
            case SoundEvents.CardDeclined:
                CardDeclined();
                break;
            case SoundEvents.HighAnxiety:
                HighAnxiety();
                break;
            case SoundEvents.CheckingOut:
                CheckingOut();
                break;
            case SoundEvents.SeeingEx:
                SeeingEx();
                break;
            case SoundEvents.ShelfFalls:
                ShelfFalls();
                break;
            case SoundEvents.PhoneMusic:
                PhoneMusic();
                break;
            case SoundEvents.BackGroundMusic:
                break;
        }
    }

    public void StartingGame()
    {
        int randomInt = Random.Range(0, startingGameClips.Count);
        if (!startingGameClips[randomInt].hasPlayed)
        {
            voicesSource.clip = startingGameClips[randomInt].audio;
            voicesSource.Play();
            startingGameClips[randomInt].hasPlayed = true;
        }
    }
    private void NPCTalking()
    {
        int randomInt = Random.Range(0, startingGameClips.Count);
        if (!startingGameClips[randomInt].hasPlayed)
        {
            voicesSource.clip = startingGameClips[randomInt].audio;
            voicesSource.Play();
        }
    }

    private void NPCTalkingToEmily()
    {
        int randomInt = Random.Range(0, npcTalkingToEmilyClips.Count);
        if (!npcTalkingToEmilyClips[randomInt].hasPlayed)
        {
            voicesSource.clip = npcTalkingToEmilyClips[randomInt].audio;
            voicesSource.Play();
            npcTalkingToEmilyClips[randomInt].hasPlayed = true;
        }
    }
    private void PickingUpItem()
    {
        int randomInt = Random.Range(0, pickingUpItemClips.Count);
        if (!pickingUpItemClips[randomInt].hasPlayed)
        {
            voicesSource.clip = pickingUpItemClips[randomInt].audio;
            voicesSource.Play();
            pickingUpItemClips[randomInt].hasPlayed = true;
        }
    }
    private void HidesInBathroom()
    {
        int randomInt = Random.Range(0, hidesInBathroomClips.Count);
        if (!hidesInBathroomClips[randomInt].hasPlayed)
        {
            voicesSource.clip = hidesInBathroomClips[randomInt].audio;
            voicesSource.Play();
            hidesInBathroomClips[randomInt].hasPlayed = true;
        }
    }
    private void PathBlocked()
    {
        int randomInt = Random.Range(0, pathBlockedClips.Count);
        if (!pathBlockedClips[randomInt].hasPlayed)
        {
            voicesSource.clip = pathBlockedClips[randomInt].audio;
            voicesSource.Play();
            pathBlockedClips[randomInt].hasPlayed = true;
        }
    }
    private void AnxietyLax()
    {
        int randomInt = Random.Range(0, anxietyLaxClips.Count);
        if (!anxietyLaxClips[randomInt].hasPlayed)
        {
            voicesSource.clip = anxietyLaxClips[randomInt].audio;
            voicesSource.Play();
            anxietyLaxClips[randomInt].hasPlayed = true;
        }
    }
    private void NPCStandingBetween()
    {
        int randomInt = Random.Range(0, npcStandingBetweenClips.Count);
        if (!npcStandingBetweenClips[randomInt].hasPlayed)
        {
            voicesSource.clip = npcStandingBetweenClips[randomInt].audio;
            voicesSource.Play();
            npcStandingBetweenClips[randomInt].hasPlayed = true;
        }
    }
    private void FireAlarm()
    {
        int randomInt = Random.Range(0, fireAlarmClips.Count);
        if (!fireAlarmClips[randomInt].hasPlayed)
        {
            voicesSource.clip = fireAlarmClips[randomInt].audio;
            voicesSource.Play();
            fireAlarmClips[randomInt].hasPlayed = true;
        }
    }
    private void Success()
    {
        int randomInt = Random.Range(0, successClips.Count);
        if (!successClips[randomInt].hasPlayed)
        {
            voicesSource.clip = successClips[randomInt].audio;
            voicesSource.Play();
            successClips[randomInt].hasPlayed = true;
        }
    }
    private void PassesOut()
    {
        int randomInt = Random.Range(0, passesOutClips.Count);
        if (!passesOutClips[randomInt].hasPlayed)
        {
            voicesSource.clip = passesOutClips[randomInt].audio;
            voicesSource.Play();
            passesOutClips[randomInt].hasPlayed = true;
        }
    }
    private void ArgumentBreaksOut()
    {
        int randomInt = Random.Range(0, argumentBreaksOutClips.Count);
        if (!argumentBreaksOutClips[randomInt].hasPlayed)
        {
            voicesSource.clip = argumentBreaksOutClips[randomInt].audio;
            voicesSource.Play();
            argumentBreaksOutClips[randomInt].hasPlayed = true;
        }
    }
    private void CardDeclined()
    {
        int randomInt = Random.Range(0, cardDeclinedClips.Count);
        if (!cardDeclinedClips[randomInt].hasPlayed)
        {
            voicesSource.clip = cardDeclinedClips[randomInt].audio;
            voicesSource.Play();
            cardDeclinedClips[randomInt].hasPlayed = true;
        }
    }
    private void HighAnxiety()
    {
        int randomInt = Random.Range(0, highAnxietyClips.Count);
        if (!highAnxietyClips[randomInt].hasPlayed)
        {
            voicesSource.clip = highAnxietyClips[randomInt].audio;
            voicesSource.Play();
            highAnxietyClips[randomInt].hasPlayed = true;
        }
    }
    private void CheckingOut()
    {
        int randomInt = Random.Range(0, checkingOutClips.Count);
        if (!checkingOutClips[randomInt].hasPlayed)
        {
            voicesSource.clip = checkingOutClips[randomInt].audio;
            voicesSource.Play();
            checkingOutClips[randomInt].hasPlayed = true;
        }
    }
    private void SeeingEx()
    {
        int randomInt = Random.Range(0, seeingExClips.Count);
        if (!seeingExClips[randomInt].hasPlayed)
        {
            voicesSource.clip = seeingExClips[randomInt].audio;
            voicesSource.Play();
            seeingExClips[randomInt].hasPlayed = true;
        }
    }
    private void ShelfFalls()
    {
        int randomInt = Random.Range(0, shelfFallsClips.Count);
        if (!shelfFallsClips[randomInt].hasPlayed)
        {
            voicesSource.clip = shelfFallsClips[randomInt].audio;
            voicesSource.Play();
            shelfFallsClips[randomInt].hasPlayed = true;
        }
    }
    private void PhoneMusic()
    {
        int randomInt = Random.Range(0, phoneMusicClips.Count);
        if (!phoneMusicClips[randomInt].hasPlayed)
        {
            backGroudSource.clip = phoneMusicClips[randomInt].audio;
            backGroudSource.Play();
            phoneMusicClips[randomInt].hasPlayed = true;
        }
    }
    private void BackGroundMusic()
    {
        int randomInt = Random.Range(0, phoneMusicClips.Count);
        if (!phoneMusicClips[randomInt].hasPlayed)
        {
            backGroudSource.clip = phoneMusicClips[randomInt].audio;
            backGroudSource.Play();
            phoneMusicClips[randomInt].hasPlayed = true;
        }
    }
}


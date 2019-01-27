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
    BackGroundMusic
}
[System.Serializable]
public struct Clips
{
    public SoundEvents sounds;
    public AudioClip audio;
    public bool hasPlayed;
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
                break;
            case SoundEvents.NPCTalking:
                break;
            case SoundEvents.NPCTalkingToEmily:
                break;
            case SoundEvents.PickingUpItem:
                break;
            case SoundEvents.HidesInBathroom:
                break;
            case SoundEvents.PathBlocked:
                break;
            case SoundEvents.AnxietyLax:
                break;
            case SoundEvents.NPCStandingBetween:
                break;
            case SoundEvents.FireAlarm:
                break;
            case SoundEvents.Success:
                break;
            case SoundEvents.PassesOut:
                break;
            case SoundEvents.ArgumentBreaksOut:
                break;
            case SoundEvents.CardDeclined:
                break;
            case SoundEvents.HighAnxiety:
                break;
            case SoundEvents.CheckingOut:
                break;
            case SoundEvents.SeeingEx:
                break;
            case SoundEvents.ShelfFalls:
                break;
            case SoundEvents.PhoneMusic:
                break;
            case SoundEvents.BackGroundMusic:
                break;
        }
    }

    private void StartingGame()
    {

    }
}


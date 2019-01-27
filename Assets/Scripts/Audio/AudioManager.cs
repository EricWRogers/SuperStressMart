﻿using System.Collections;
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
public struct Clips
{
    public SoundEvents sounds;
    public AudioClip audio;
    public bool hasPlayed;
}

public class AudioManager : MonoBehaviour {

    public List<Clips> clips= new List<Clips>();

    //public AudioClip backGroundMusic;

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
        }
    }
}

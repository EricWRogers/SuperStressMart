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
    ShelfFalls
}

public class AudioManager : MonoBehaviour
{
    //private SoundEvents soundEvents = new SoundEvents();
   // [SerializeField]
    //private AudioSource voiceSource;

    void Start()
    {

    }

    void Update()
    {

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
        }
    }
}

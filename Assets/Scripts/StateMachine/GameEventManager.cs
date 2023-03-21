using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEventManager
{
    public static event UnityAction MainMenuEvent;
    public static event UnityAction StartTimerEvent;
    public static event UnityAction RacingEvent;
    public static event UnityAction FinishEvent;


    public static void OnMainMenu()
    {
        MainMenuEvent?.Invoke();
    }

    public static void OnGameStart()
    {
        StartTimerEvent?.Invoke();
    }

    public static void OnRacing()
    {
        RacingEvent?.Invoke();
    }

    public static void OnGameFinished()
    {
        FinishEvent?.Invoke();
    }
}

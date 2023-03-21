using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

public class GameStateStartTimer : GameState
{
    public GameStateStartTimer(StateManager stateManager) : base("StartTimer", stateManager)
    {

    }


    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.StartTimerEvent += startRace;
        Debug.Log("Entered Timer");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.StartTimerEvent -= startRace;
        Debug.Log("Exited Timer");
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            startRace();
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void startRace()
    {
        StateManager.SetNewState(StateManager.Racing);
    }
}

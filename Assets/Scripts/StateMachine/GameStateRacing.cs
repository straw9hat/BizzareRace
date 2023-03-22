using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateRacing : GameState
{
    public GameStateRacing(StateManager stateManager) : base("Racing", stateManager)
    {

    }

    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.RacingEvent += showRaceResults;
        Debug.Log("Entered Racing state");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.RacingEvent -= showRaceResults;
        Debug.Log("Exited Racing state");
    }

    public override void Update()
    {
        base.Update();
        if (lapCounter.lapNum == 3)
        {
            showRaceResults();
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void showRaceResults()
    {
        StateManager.SetNewState(StateManager.Finish);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMainMenu : GameState
{
    public GameStateMainMenu(StateManager stateManager) : base("MainMenu", stateManager)
    {

    }

    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.MainMenuEvent += startGameTimer;
        Debug.Log("Entered Main Menu");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.MainMenuEvent -= startGameTimer;
        Debug.Log("Exited Main Menu");
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            startGameTimer();
        }

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void startGameTimer()
    {
        StateManager.SetNewState(StateManager.StartTimer);
    }
}

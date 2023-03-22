using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class GameStateMainMenu : GameState
{
    private GameObject mainMenu;
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
        mainMenu = GameObject.Find("MainMenu");
        GameEventManager.MainMenuEvent += startGameTimer;
        Debug.Log("Entered Main Menu");
    }

    public override void OnExit()
    {
        base.OnExit();
        mainMenu.SetActive(false);
        GameEventManager.MainMenuEvent -= startGameTimer;
        Debug.Log("Exited Main Menu");
    }

    public override void Update()
    {
        base.Update();
        if(Input.anyKey)
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

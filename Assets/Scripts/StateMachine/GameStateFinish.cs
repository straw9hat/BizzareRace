using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateFinish : GameState
{
    public GameStateFinish(StateManager stateManager) : base("Finish", stateManager)
    {

    }


    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.FinishEvent += restartGame;
        Debug.Log("Entered results");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.FinishEvent -= restartGame;
        Debug.Log("Exited results");
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            restartGame();
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void restartGame()
    {
        StateManager.SetNewState(StateManager.MainMenu);
    }
}

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
        if (GameObject.Find("Car").transform.position.z > 0)
        {
            Utils.FindIncludingInactive("FinishScreen").SetActive(true);
            Utils.FindIncludingInactive("P1Win").SetActive(true);
        }
        else
        {
            Utils.FindIncludingInactive("FinishScreen").SetActive(true);
            Utils.FindIncludingInactive("P2Win").SetActive(true);
        }
        GameEventManager.FinishEvent += restartGame;
        Debug.Log("Entered results");
    }

    public override void OnExit()
    {
        base.OnExit();
        Utils.FindIncludingInactive("FinishScreen").SetActive(false);
        Utils.FindIncludingInactive("P1Win").SetActive(false);
        Utils.FindIncludingInactive("P2Win").SetActive(false);
        GameEventManager.FinishEvent -= restartGame;
        Debug.Log("Exited results");
    }

    public override void Update()
    {
        base.Update();
        if (Input.anyKey)
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

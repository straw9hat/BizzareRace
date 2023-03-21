using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Playables;

public class StateManager : MonoBehaviour
{
    public GameStateMainMenu MainMenu;
    public GameStateStartTimer StartTimer;
    public GameStateRacing Racing;
    public GameStateFinish Finish;


    protected GameState CurState;

    private void Awake()
    {
        // initialize SDV player states here
        MainMenu = new GameStateMainMenu(this);
        StartTimer = new GameStateStartTimer(this);
        Racing = new GameStateRacing(this);
        Finish = new GameStateFinish(this);
    }

    // Start is called before the first frame update
    protected void Start()
    {
        CurState = GetInitialState();
        if (CurState != null)
        {
            CurState.OnEnter();
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        if (CurState != null)
        {
            CurState.Update();
            UpdateAnimator();
        }
    }

    public void SetNewState(GameState NewState)
    {
        CurState.OnExit();
        CurState = NewState;
        CurState.OnEnter();
    }

    // will be defined in child classes aka mini games' state machines
    protected GameState GetInitialState()
    {
        return MainMenu;
    }

    public void OnEnable()
    {
        GameEventManager.StartTimerEvent += dummy;

    }

    public void OnDisable()
    {
        GameEventManager.StartTimerEvent -= dummy;
    }

    protected void UpdateAnimator()
    {
    }

    public GameState GetCurrentState()
    {
        return CurState;
    }
    private void dummy()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameState
{
    public string Name;
    protected StateManager StateManager;

    public GameState(string _name, StateManager _StateManager)
    {
        this.Name = _name;
        this.StateManager = _StateManager;
    }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void Update() { }
    public virtual GameState GetState()
    {
        return this;
    }
}

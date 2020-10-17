﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StackFSM : MonoBehaviour
{
    private List<State> stateStack;

    // Update is called once per frame
    void Update()
    {
        State currentState = GetCurrentState();

        if(currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    public void PopState()
    {
        State currentState = GetCurrentState();
        if (currentState != null)
        {
            currentState.OnPop();
            stateStack.Remove(currentState);
        }
    }

    public void PushState(State newState)
    {
        if(GetCurrentState() != newState)
        {
            newState.OnPush();
            stateStack.Add(newState);
        }
    }

    public void ChangeState(State newState)
    {
        if (GetCurrentState() != newState)
        {
            PopState();
            PushState(newState);
        }
    }

    public State GetCurrentState()
    {
        return stateStack.Count > 0 ? stateStack[stateStack.Count - 1] : null;
    }
}
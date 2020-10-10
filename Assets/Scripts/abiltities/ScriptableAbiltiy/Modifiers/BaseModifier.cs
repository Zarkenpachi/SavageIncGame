﻿using System;
using System.Collections.Generic;
using UnityEngine;

public enum ModifierStage
{
    PRE_ACTION,
    ACTION,
    POST_ACTION
}

public enum ModifierTarget
{
    CASTER,
    TARGET
}

public abstract class BaseModifier : ScriptableObject
{
    [SerializeField]
    protected string modifierName;
    [SerializeField]
    protected string modifierDescription;

    /// <summary>
    /// How Long is the modifier active for till it gets removed from the target?
    /// activePeriod = 0 means the Modifier is only affected for a single frame (E.G instant damage)
    /// </summary>
    [SerializeField]
    protected float activePeriod = 0.0f;

    /// <summary>
    /// How many times to apply the modifier effect?
    /// applyFrequency = 0.0f means the effect only gets applied once
    /// applyFrequency = 0.5f means the effect gets applied every 0.5 seconds while the effective is active
    /// </summary>
    [SerializeField]
    protected float applyFrequency = 0.0f;

    protected float currentActiveTime = 0.0f;

    #region properties
    public string ModifierName => modifierName;
    public string ModifierDescription => modifierDescription;
    public float ActivePeriod => activePeriod;
    public float ApplyFrequency => applyFrequency;
    #endregion

    public abstract void OnApply(CharacterBase characterBase, MonoBehaviour mono);
    public abstract void OnRemove(CharacterBase characterBase);

    protected abstract void OnTick(CharacterBase characterBase);
}

[Serializable]
public struct AbilityModifier
{
    public BaseModifier Modifier;
    public ModifierStage Stage;
    public ModifierTarget Target;
}
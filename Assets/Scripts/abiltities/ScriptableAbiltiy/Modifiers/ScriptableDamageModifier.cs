﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "AbilityModifiers/DamageModifier")]
public class ScriptableDamageModifier : ScriptableModifier
{
    public float Damage;

    public override void OnApply(CharacterBase targetCharacter, ref List<CharacterBase> affectedCharacters)
    {
        affectedCharacters.Add(targetCharacter);
    }

    public override void OnRemove(CharacterBase targetCharacter, ref List<CharacterBase> affectedCharacters)
    {
        affectedCharacters.Clear();
    }

    public override void OnTick(CharacterBase targetCharacter, ref List<CharacterBase> affectedCharacters)
    {
        ApplyEffects(targetCharacter);

        //TODO add damage on tick
        Debug.Log($"ScriptableDamageModifier: {ModifierName} applied {Damage} damage");
    }
}
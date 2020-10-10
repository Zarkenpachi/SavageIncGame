﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ModifierHandler
{
    private AbilityModifier[] allModifiers;

    //cache stage modifiers
    private List<AbilityModifier> preModifiers;
    private List<AbilityModifier> actionModifiers;
    private List<AbilityModifier> postModifiers;

    public ModifierHandler(AbilityModifier[] modifiers)
    {
        allModifiers = modifiers;
        preModifiers = new List<AbilityModifier>();
        actionModifiers = new List<AbilityModifier>();
        postModifiers = new List<AbilityModifier>();

        foreach (var modifier in modifiers)
        {
            switch (modifier.Stage)
            {
                case ModifierStage.PRE_ACTION:
                    preModifiers.Add(modifier);
                    break;
                case ModifierStage.ACTION:
                    actionModifiers.Add(modifier);
                    break;
                case ModifierStage.POST_ACTION:
                    postModifiers.Add(modifier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public void ApplyPreActionModifiers(CharacterBase characterBase, CharacterBase targetCharacterBase)
    {
        foreach (var abilityModifier in preModifiers)
        {
            applyModifier(abilityModifier,characterBase,targetCharacterBase);
        }
    }

    public void ApplyActionModifiers(CharacterBase characterBase, CharacterBase targetCharacterBase)
    {
        foreach (var abilityModifier in actionModifiers)
        {
            applyModifier(abilityModifier, characterBase, targetCharacterBase);
        }
    }

    public void ApplyPostActionModifiers(CharacterBase characterBase, CharacterBase targetCharacterBase)
    {
        foreach (var abilityModifier in postModifiers)
        {
            applyModifier(abilityModifier, characterBase, targetCharacterBase);
        }
    }

    public void RemoveEffects(CharacterBase characterBase, CharacterBase targetCharacterBase)
    {
        foreach (var abilityModifier in allModifiers)
        {
            if (abilityModifier.Modifier.ActivePeriod <= 0.0f)
            {
                switch (abilityModifier.Target)
                {
                    case ModifierTarget.CASTER:
                        abilityModifier.Modifier.OnRemove(characterBase);
                        break;
                    case ModifierTarget.TARGET:
                        abilityModifier.Modifier.OnRemove(targetCharacterBase);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    private void applyModifier(AbilityModifier abilityModifier, CharacterBase characterBase,
        CharacterBase targetCharacterBase)
    {
        switch (abilityModifier.Target)
        {
            case ModifierTarget.CASTER:
                abilityModifier.Modifier.OnApply(characterBase, characterBase);
                break;
            case ModifierTarget.TARGET:
                abilityModifier.Modifier.OnApply(targetCharacterBase, targetCharacterBase);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
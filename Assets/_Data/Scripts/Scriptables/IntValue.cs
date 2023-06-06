using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntValue", menuName = "Scriptable/IntValue")]
public class IntValue : ScriptableObject, ISerializationCallbackReceiver
{
    public int lives;

    [NonSerialized]
    public int runtimeLives;

    public void OnAfterDeserialize()
    {
        runtimeLives = lives;
    }
    public void OnBeforeSerialize()
    {

    }

    public int getLives()
    {
        return lives;
    }

}

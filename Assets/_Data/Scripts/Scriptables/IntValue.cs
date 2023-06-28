using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "IntValue", menuName = "Scriptable/IntValue")]
public class IntValue : ScriptableObject, ISerializationCallbackReceiver
{
    public int value;

    [NonSerialized]
    public int runtimeValue;

    public void OnAfterDeserialize()
    {
        runtimeValue = value;
    }
    public void OnBeforeSerialize()
    {

    }

    public int getValue()
    {
        return value;
    }

}

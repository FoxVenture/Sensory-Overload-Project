using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Memory Card")]
public class CardScriptable : ScriptableObject
{
    public int key;

    public Material front;

}
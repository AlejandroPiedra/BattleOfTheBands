using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Game", menuName = "ScriptableObjects/Game")]
public class GameScriptableObject : ScriptableObject
{
    public PlayerScript player1;
    public PlayerScript player2;
    public AudioSource song;
}

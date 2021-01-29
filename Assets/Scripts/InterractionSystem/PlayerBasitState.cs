using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasitState : MonoBehaviour
{
    public PlayerState State;
    public bool isInteracting { get; set; }
    public void Awake()
    {
        State = PlayerState.NotInterracting;
    }
}

public enum PlayerState
{
    NotInterracting,
    Interracting
}

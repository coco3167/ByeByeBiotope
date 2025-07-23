using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private MicroVolume microVolume;
    
    private PlayerInputManager m_playerInputManager;

    private void Awake()
    {
        m_playerInputManager = GetComponent<PlayerInputManager>();
        
        m_playerInputManager.onPlayerJoined += OnPlayerJoined;
        m_playerInputManager.onPlayerLeft += OnPlayerLeft;
    }

    private void OnPlayerJoined(PlayerInput input)
    {
        input.GetComponent<PlayerVolumeReceiver>().Initialize(microVolume);
    }

    private void OnPlayerLeft(PlayerInput input)
    {
        return;
    }
}

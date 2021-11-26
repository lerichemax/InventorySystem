using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isPaused;
    public bool IsPaused
    {
        get { return _isPaused; }
    }

    private void Awake()
    {
        _isPaused = false;
    }

    public void SetPause(bool isPaused)
    {
        _isPaused = isPaused;
        Time.timeScale = _isPaused ? 0f : 1f;
    }
}

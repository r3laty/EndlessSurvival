using System.Collections.Generic;
using UnityEngine;

public class PauseData
{
    public List<IPauseable> Pauseables = new List<IPauseable>();
    public void Pause()
    {
        foreach (var pauseable in Pauseables)
        {
            pauseable.GamePause();
        }
    }
    public void UnPause()
    {
        foreach (var pauseable in Pauseables)
        {
            pauseable.GameReset();
        }
    }
}

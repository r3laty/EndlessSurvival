using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseData
{
    public List<IPauseable> pauseables = new List<IPauseable>();
    public void Pause()
    {
        Debug.Log(pauseables.Count + " list of IPauseable");
        foreach (var pauseable in pauseables)
        {
            if (pauseable != null)
            {
                pauseable.SetPause();
            }
        }
    }
    public void UnPause()
    {
        foreach (var pauseable in pauseables)
        {
            if (pauseable != null)
            {
                pauseable.SetUnPause();
            }
        }
    }
}

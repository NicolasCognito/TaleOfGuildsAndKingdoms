using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OutputModel
{
    private string _name;
    private int _probability;

    public int Probability { get => _probability; set => _probability = value; }

    public OutputModel(string name, int probability)
    {
        _name = name;
        _probability = probability;
    }

    public void DebugOutput()
    {
        Debug.Log(_name + " " + _probability);
    }
}

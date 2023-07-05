using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaborPool
{
    // List of laborers in the labor pool.
    public List<LaborerModel> Laborers { get; }

    public LaborPool()
    {
        Laborers = new List<LaborerModel>();
    }

    // Method to add a laborer to the labor pool.
    public void AddLaborer(LaborerModel laborer)
    {
        Laborers.Add(laborer);
    }

    // Method to remove a laborer from the labor pool.
    public void RemoveLaborer(LaborerModel laborer)
    {
        Laborers.Remove(laborer);
    }

    // Method to get laborers of a certain type.
    public List<LaborerModel> GetLaborersOfType(string laborerType)
    {
        return Laborers.Where(l => l.qualification == laborerType).ToList();
    }
}
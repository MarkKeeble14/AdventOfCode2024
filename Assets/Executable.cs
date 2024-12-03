using UnityEngine;
// Quicksort from here: https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php

public abstract class Executable : MonoBehaviour
{
    [SerializeField] private bool executeOnAwake = true;
    [SerializeField] protected bool print = false;

    private void Awake()
    {
        if (executeOnAwake)
        {
            Execute();
        }
    }

    protected abstract void Execute();
}

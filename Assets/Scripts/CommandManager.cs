using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;
    public static CommandManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Command Manager is NULL!!!");
            return _instance;
        }
    }
    private List<ICommand> _scaleChangesBuffer = new List<ICommand>();
    private void Awake()
    {
        _instance = this;
    }
    public void AddCommand(ICommand command)
    {
        _scaleChangesBuffer.Add(command);
    }
    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }
    private IEnumerator PlayRoutine()
    {
        foreach (var command in _scaleChangesBuffer)
        {
            command.Execute();
            yield return new WaitForSeconds(1f);
        }
    }
    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }
    private IEnumerator RewindRoutine()
    {
        foreach (var command in Enumerable.Reverse(_scaleChangesBuffer))
        {
            command.Undue();
            yield return new WaitForSeconds(1f);
        }
    }
    public void Done()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            cube.GetComponent<Transform>().localScale = Vector3.one;
        }
    }
    public void Reset()
    {
        _scaleChangesBuffer.Clear();
    }
}

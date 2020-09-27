using UnityEngine;

public class ScaleChangeCommand : ICommand
{
    private Transform _cubeTransform;
    private Transform _previousCubeTransform;
    private Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    
    public ScaleChangeCommand(Transform cubeTransform)
    {
        this._cubeTransform = cubeTransform;
    }
    public void Execute()
    {
        _previousCubeTransform = _cubeTransform;
        _cubeTransform.localScale -= scaleChange;
    }

    public void Undue()
    {
        _cubeTransform.localScale += scaleChange;
    }
}

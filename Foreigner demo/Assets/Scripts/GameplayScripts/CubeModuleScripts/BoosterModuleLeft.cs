using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BoosterModuleLeft : MonoBehaviour, ICubeModule, IModuleDependent
{
    private bool _actionFlag = true;
    private bool _cubeEnabled = true;
    private Vector3 _speed = new Vector3();
    public void DisableCubeFunction()
    {
        _cubeEnabled = false;
    }

    public void OnClickAction()
    {
        if (_actionFlag && _cubeEnabled)
        {
            this.gameObject.GetComponentInParent<Rigidbody2D>().AddRelativeForce(_speed, ForceMode2D.Impulse);
            _actionFlag = false;
            _resetFlag();
        }
    }

    public void EnableCubeFunction()
    {
        _cubeEnabled = true;
    }

    public void OnReleaseAction()
    {
        return;
    }

    private async void _resetFlag()
    {
        await Task.Delay(2000);
        _actionFlag = true;
    }

    public void CalculateWithNumberOfModules(int NumberOfModules)
    {
        this._speed.x = -6 * NumberOfModules;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BoosterModuleRight : MonoBehaviour,ICubeModule, IModuleDependent
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
            Rigidbody2D parentBody = this.gameObject.GetComponentInParent<Rigidbody2D>();
            if (parentBody.velocity.y < 0)
            {
                parentBody.velocity = new Vector2(parentBody.velocity.x, 0);
            }
            parentBody.AddRelativeForce(_speed, ForceMode2D.Impulse);
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
        _speed.x = 6 * NumberOfModules;
    }
}

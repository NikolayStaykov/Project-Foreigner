using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadModuleLeft : MonoBehaviour, ICubeModule, IModuleDependent
{
    private bool _actionFlag = false;
    private bool _cubeEnabled = true;
    private int _numberOFMofules;
    private Vector3 _speed = new Vector3();

    public void DisableCubeFunction()
    {
        _cubeEnabled= false;
    }

    public void OnClickAction()
    {
        if (_cubeEnabled)
        {
            _initiateMovement();
        }
    }

    private void _initiateMovement()
    {
        if (this.gameObject.GetComponentInParent<Rigidbody2D>().velocity.y < 0.01f && this.gameObject.GetComponentInParent<Rigidbody2D>().velocity.y > -0.01)
        {
            _actionFlag = true;
        }
    }

    public void EnableCubeFunction()
    {
        _cubeEnabled= true;
    }

    public void OnReleaseAction()
    {
        _actionFlag = false;
        this.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, this.gameObject.GetComponentInParent<Rigidbody2D>().velocity.y);
    }

    public void Update()
    {
        if (_actionFlag) this.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(_speed, ForceMode2D.Force);
    }

    public void CalculateWithNumberOfModules(int NumberOfModules)
    {
        _speed.x = -NumberOfModules;
    }
}

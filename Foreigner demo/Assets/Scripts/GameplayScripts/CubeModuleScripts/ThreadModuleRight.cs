using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadModuleRight : MonoBehaviour, ICubeModule
{
    private bool _actionFlag = false;
    public void OnClickAction()
    {
        if (this.gameObject.GetComponentInParent<Rigidbody2D>().velocity.y < 0.01f && this.gameObject.GetComponentInParent<Rigidbody2D>().velocity.y > -0.01)
        {
            _actionFlag = true;
        }
    }

    public void OnReleaseAction()
    {
        _actionFlag= false;
        this.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, this.gameObject.GetComponentInParent<Rigidbody2D>().velocity.y);
    }

    public void Update()
    {
        if (_actionFlag) this.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(new Vector3(1f, 0, 0), ForceMode2D.Force);
    }
}

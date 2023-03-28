using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrapplingHookScript : MonoBehaviour
{

    public LineRenderer Cable;
    private GrapplingHookModule _module;
    private bool _hookSecured = false;
    private Vector3 _speed = new Vector3(0,10,0);
    private float _currentLength = 12;
    public void SetGrapplingHookModule(GrapplingHookModule module)
    {
        this._module = module;
    }
    public void Update()
    {
        _RenderCable();
        if (!_hookSecured)
        {
            _moveHook();
        }
    }

    private void _RenderCable()
    {
        Cable.SetPosition(0, this.gameObject.transform.position);
        Cable.SetPosition(1, _module.gameObject.transform.position);
    }

    private void _moveHook()
    {
        _currentLength -= _speed.y * Time.deltaTime;
        this.gameObject.transform.Translate(_speed * Time.deltaTime);
        if (_currentLength < 0 )
        {
            ResetHook();
        }
    }

    public void ResetHook()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        this._hookSecured = true;
        if(collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D colliderBody))
        {
            FixedJoint2D joint = this.AddComponent<FixedJoint2D>();
            joint.connectedBody= colliderBody;
        } else
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        _module.HookSecured(this.GetComponent<Rigidbody2D>());
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrapplingHookModule : MonoBehaviour, ICubeModule
{
    public GameObject Hook;
    public Transform HookSpawnPoint;
    private GameObject _tempHook;
    private bool _cubeEnabled = true;
    private bool _hookLaunched = false;
    private bool _hookSecured = false;
    private bool _actionFlag = false;


    public void DisableCubeFunction()
    {
        _cubeEnabled = false;
    }

    public void EnableCubeFunction()
    {
        _cubeEnabled = true;
    }

    public void OnClickAction()
    {
        if (_cubeEnabled)
        {
            if (!_hookLaunched)
            {
                _hookLaunched=true;
                this.gameObject.AddComponent<Rigidbody2D>().mass = 0.001f;
                this.gameObject.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;
                this.gameObject.AddComponent<FixedJoint2D>().connectedBody = this.GetComponentInParent<MainAIModule>().gameObject.GetComponent<Rigidbody2D>();
                this.gameObject.AddComponent<SpringJoint2D>().dampingRatio = 1;
                _tempHook = Instantiate(Hook, HookSpawnPoint.position, HookSpawnPoint.rotation, null);
                _tempHook.GetComponent<GrapplingHookScript>().SetGrapplingHookModule(this);
            }
            if (_hookSecured)
            {
                _actionFlag= true;
            }
        }
    }

    public void OnReleaseAction()
    {
        _actionFlag= false;
    }
    void FixedUpdate()
    {
        if (_actionFlag)
        {
            _reelInGrappleHook();
        }
    }

    private void _reelInGrappleHook()
    {
        if(this.TryGetComponent<SpringJoint2D>(out SpringJoint2D joint) && joint.distance > 0.005f )
        {
            joint.distance -= 1 * Time.deltaTime;
        }
    }

    public void HookSecured(Rigidbody2D HookBody)
    {
        SpringJoint2D joint = this.gameObject.GetComponentInParent<SpringJoint2D>();
        joint.enabled = true;
        joint.connectedBody = HookBody;
        joint.autoConfigureDistance = false;
        this.GetComponent<Rigidbody2D>().mass = 1f;
        _hookSecured = true;
    }

    public void OnDoubleClickAction()
    {
        _hookLaunched = _hookLaunched = false;
        Destroy(this.gameObject.GetComponent<FixedJoint2D>());
        Destroy(this.gameObject.GetComponent<SpringJoint2D>());
        Destroy(this.gameObject.GetComponent<Rigidbody2D>());
        Destroy(_tempHook);
    }
}

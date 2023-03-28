using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class GrapplingHookModule : MonoBehaviour, ICubeModule
{
    public GameObject Hook;
    public Transform HookSpawnPoint;
    private GameObject _tempHook;
    private bool _cubeEnabled = true;

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
            _cubeEnabled= false;
            this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            _tempHook = Instantiate(Hook, HookSpawnPoint.position, HookSpawnPoint.rotation, null);
            _tempHook.GetComponent<GrapplingHookScript>().SetGrapplingHookModule(this);
        }
    }

    public void OnReleaseAction()
    {
        throw new System.NotImplementedException();
    }
    void Update()
    {

    }
    public void HookSecured(Rigidbody2D HookBody)
    {
        SpringJoint2D joint = this.gameObject.GetComponent<SpringJoint2D>();
        joint.enabled = true;
        joint.connectedBody = HookBody;
        joint.autoConfigureDistance = false;
    }

    public void SetNumberOfModules(int NumberOfModules)
    {
        throw new System.NotImplementedException();
    }
}

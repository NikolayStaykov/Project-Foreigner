using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAIModule : MonoBehaviour, ICubeModule
{
    private bool _cubeEnabled = true;
    public void DisableCubeFunction()
    {
        _cubeEnabled= false;
    }

    public void OnClickAction()
    {
        if(_cubeEnabled)
        {
            this.gameObject.transform.Translate(new Vector3(0, 2, 0), Space.World);
            this.gameObject.transform.rotation = new Quaternion();
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

    public void UpdateModules()
    {
        int numberOfModules = this.GetComponentsInChildren<ICubeModule>().Length;
        Debug.Log(numberOfModules);
        foreach (IModuleDependent module in this.GetComponentsInChildren<IModuleDependent>())
        {
            module.CalculateWithNumberOfModules(1);
        }
    }

    public void Awake()
    {
        UpdateModules();
    }
}

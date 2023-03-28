using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICubeModule 
{
    public void OnClickAction();

    public void OnReleaseAction();

    public void DisableCubeFunction();

    public void EnableCubeFunction();
}

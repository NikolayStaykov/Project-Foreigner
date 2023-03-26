using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAIModule : MonoBehaviour, ICubeModule
{

    public void OnClickAction()
    {
        this.gameObject.transform.Translate(new Vector3(0, 2, 0), Space.World);
        this.gameObject.transform.rotation = new Quaternion();
    }

    public void OnReleaseAction()
    {
        throw new System.NotImplementedException();
    }
}

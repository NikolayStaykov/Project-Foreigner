using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BoosterCubeModuleLeft : MonoBehaviour
{
    private bool _actionFlag = true;
    public void OnClickAction()
    {
        if (_actionFlag)
        {
            this.gameObject.GetComponentInParent<Rigidbody2D>().AddRelativeForce(new Vector3(-6, 0, 0), ForceMode2D.Impulse);
            _actionFlag = false;
            _resetFlag();
        }
    }

    public void OnReleaseAction()
    {
        throw new System.NotImplementedException();
    }

    private async void _resetFlag()
    {
        await Task.Delay(5000);
        _actionFlag = true;
    }
}

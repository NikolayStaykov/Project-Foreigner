using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _offset = new Vector3(0,2.5f,-10);
    void Start()
    {
        _player = FindObjectOfType<MainAIModule>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _player.transform.position + _offset;
    }
}

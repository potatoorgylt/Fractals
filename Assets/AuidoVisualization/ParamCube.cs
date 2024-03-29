﻿using UnityEngine;
using System.Collections;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _maxScale;
    public bool _useBuffer;
    Material _material;
    // Use this for initialization
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            if (AudioPeer._audioBandBuffer[_band] == AudioPeer._audioBandBuffer[_band])
            {
                Debug.Log(AudioPeer._audioBandBuffer[_band]);
                transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._audioBandBuffer[_band] * _maxScale) + _startScale, transform.localScale.z);
            }
            Color _color = new Color(AudioPeer._audioBandBuffer[_band], AudioPeer._audioBandBuffer[_band], AudioPeer._audioBandBuffer[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
        else if (!_useBuffer)
        {
            if (AudioPeer._audioBandBuffer[_band] == AudioPeer._audioBandBuffer[_band])
            {
                Debug.Log(AudioPeer._audioBandBuffer[_band]);
                transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._audioBand[_band] * _maxScale) + _startScale, transform.localScale.z);
            }
            Color _color = new Color(AudioPeer._audioBand[_band], AudioPeer._audioBand[_band], AudioPeer._audioBand[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
       
    }
}

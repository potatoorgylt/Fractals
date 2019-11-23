﻿using UnityEngine;
using System.Collections;

public class ScaleOnAmplitude : MonoBehaviour
{
    public float _startScale, _maxScale;
    public bool _useBuffer;
    Material _material;
    public float _red, _green, _blue;

    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer._Amplitude * _maxScale) + _startScale, (AudioPeer._Amplitude * _maxScale) + _startScale, (AudioPeer._Amplitude * _maxScale) + _startScale);

            Color _color = new Color(_red * AudioPeer._Amplitude, _green * AudioPeer._Amplitude, _blue * AudioPeer._Amplitude);
            _material.SetColor("_EmissionColor", _color);
        }
        else if (!_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer._AmplitudeBuffer * _maxScale) + _startScale, (AudioPeer._AmplitudeBuffer * _maxScale) + _startScale, (AudioPeer._AmplitudeBuffer * _maxScale) + _startScale);

            Color _color = new Color(_red * AudioPeer._AmplitudeBuffer, _green * AudioPeer._AmplitudeBuffer, _blue * AudioPeer._AmplitudeBuffer);
            _material.SetColor("_EmissionColor", _color);
        }

    }
}

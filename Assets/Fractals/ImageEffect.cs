using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]

public class ImageEffect : MonoBehaviour
{
    public Material material;
    public Vector2 pos;
    public Vector2 nextPos = Vector2.zero;
    private Vector2 distance;
    public Vector2 minPos = new Vector2(0.351f, 0.351f);
    public float scale;
    public Color exposure;

    public float speed = 0.1f;
    public bool toggle = true;
    bool reverse = false;


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }

    private void UpdateShader()
    {
        material.SetVector("_Area", new Vector4(pos.x, pos.y, scale, scale));
        exposure = new Color(AudioPeer._Amplitude, AudioPeer._Amplitude, AudioPeer._Amplitude, 1);
        Debug.Log(exposure);
        material.SetColor("_Exposure", exposure);
    }

    private void Update()
    {
        UpdateShader();

        Vector3 mousePos = Input.mousePosition;

        mousePos.x -= Screen.width / 2f;
        mousePos.y -= Screen.height / 2f;

        if (Input.GetButtonDown("Fire1"))
        {
            nextPos = new Vector2(mousePos.x / Screen.width, mousePos.y / Screen.height) * -1f * scale;
            distance = pos - nextPos;
        }

        if (Input.GetButton("Fire1"))
            pos = distance + new Vector2(mousePos.x / Screen.width, mousePos.y / Screen.height) * -1f * scale;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (toggle)
                toggle = false;
            else
                toggle = true;
        }
        
        if (toggle)
        {
            
            if (scale >= 0.0005 && reverse == false)
                scale -= scale * Time.deltaTime * speed;
            else
                reverse = true;


            if (scale <= 1 && reverse == true)
                scale += scale * Time.deltaTime * speed;
            else
                reverse = false;
        }
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Rendering.DebugUI;

public class Shield : MonoBehaviour
{
    public MeshRenderer _renderer;
    [SerializeField] float dissolveSpeed = 0.6f;
    [SerializeField] float waveAmplitude = 1f;
    [SerializeField] float pulseSpeed = 3f;
    private Vector3 _baseScale;

    void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        //StartCoroutine(DeactivateShield());
        _baseScale = transform.localScale;
    }

    private void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * waveAmplitude;
        transform.localScale = _baseScale * scale;
    }

    public IEnumerator DeactivateShield()
    {
        if(_renderer == null) _renderer = GetComponent<MeshRenderer>();
        _renderer.sharedMaterial.SetFloat("_DissolveFactor", 0f);
        float start = 0f;
        float target = 1.1f;
        float lerp = 0f;
        while(lerp < 1)
        {
            float value = Mathf.Lerp(start, target, lerp);
            _renderer.sharedMaterial.SetFloat("_DissolveFactor", value);
            lerp += Time.deltaTime * dissolveSpeed;
            yield return null;
        }
        _renderer.sharedMaterial.SetFloat("_DissolveFactor", 1f);
        Destroy(this);
    }

    public IEnumerator ActivateShield()
    {
        if (_renderer == null) _renderer = GetComponent<MeshRenderer>();
        _renderer.sharedMaterial.SetFloat("_DissolveFactor", 1f);
        float start = 1f;
        float target = 0f;
        float lerp = 0f;
        while (lerp < 1)
        {
            float value = Mathf.Lerp(start, target, lerp);
            _renderer.sharedMaterial.SetFloat("_DissolveFactor", value);
            lerp += Time.deltaTime * dissolveSpeed;
            yield return null;
        }
        _renderer.sharedMaterial.SetFloat("_DissolveFactor", 0f);
    }
}

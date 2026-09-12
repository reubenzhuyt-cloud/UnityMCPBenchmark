using UnityEngine;

/// <summary>
/// L8/L10 粒子触发。
/// </summary>
public class VFXTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private bool playOnEnter = true;
    [SerializeField] private bool playOnTrigger = true;

    public ParticleSystem ParticleSystemRef => ps;

    public void SetParticleSystem(ParticleSystem value) => ps = value;

    public void Play()
    {
        if (ps == null) return;
        ps.Play(true);
    }

    public void Stop()
    {
        if (ps == null) return;
        ps.Stop(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playOnEnter || !playOnTrigger) return;
        Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptWithDamage : MonoBehaviour
{
    private Animator _animator;
    public Transform attackpoint;
    public LayerMask enemylayer;
    public float attackrange = 0.5f;
    public int attackdamage = 40;
    public Button attackButton;

    public AudioSource damageSoundSource; // Reference to the AudioSource for damage sound

    void Start()
    {
        _animator = GetComponent<Animator>();
        attackButton.onClick.AddListener(Attack);
    }

    public float attackrate = 2f;
    float nextattacktime = 0f;

    void Attack()
    {
        if (Time.time >= nextattacktime)
        {
            _animator.SetTrigger("attack");
            Collider[] hitenemies = Physics.OverlapSphere(attackpoint.position, attackrange, enemylayer);
            foreach (Collider enemy in hitenemies)
            {
                enemy.GetComponent<hsb_enemy>().takedamage(attackdamage);
                PlayDamageSound();
            }
            nextattacktime = Time.time + 0.5f / attackrate;
        }
    }

   

    void PlayDamageSound()
    {
        if (damageSoundSource != null)
        {
            damageSoundSource.Play();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);   
    }
}

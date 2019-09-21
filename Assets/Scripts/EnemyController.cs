using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    Animator animator;
    EnemyAnimationEvents eventTrigger;
    CharacterStats targetCharacter;
    public bool canDamage = false;
    public bool canExit = false;
    // Use this for initialization
    void Start() {
        target = PlayerManager.instance.player.transform;
        targetCharacter = PlayerManager.instance.player.GetComponent<CharacterStats>();
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        animator = GetComponentInChildren<Animator>();
        eventTrigger = GetComponentInChildren<EnemyAnimationEvents>();
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(target.position, transform.position);

        if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Stunned") || animator.GetCurrentAnimatorStateInfo(0).IsName("GetHit") || targetCharacter.currentHealth <= 0)){
        
        if (distance <= lookRadius)
        {
            if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsName("Death")))
            {
                agent.SetDestination(target.position);
            }

            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                   if (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsName("Death")))
                   {
                        eventTrigger.targetStatsChild = targetStats;
                        eventTrigger.combatChild = combat;
                        animator.SetTrigger("attack");
                   }
                    if (canDamage)
                        canExit = true;
                }
                FaceTarget();
                }
        }
        }
    }

     void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

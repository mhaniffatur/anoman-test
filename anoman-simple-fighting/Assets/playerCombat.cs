using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator animator;
    public int normalAttackCounter = 0;

    string[] normalAttack = {"singleTap1", "singleTap2", "singleTap3", "singleTap4"};
    string[] hitAnimation = {"leftHit", "rightHit", "leftHit", "rightHit"};
    string[] blockAnimation = {"leftBlock", "rightBlock", "leftBlock", "rightBlock"};
    string[] comboAttack = {"combo1", "combo2"};


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            combo();
        }
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            elbowAttack();
        }
    }

    // ==============================================

    void Attack()
    {
        animator.SetTrigger(normalAttack[normalAttackCounter]);
        animator.SetTrigger((Random.Range(0, 5) == 1) ? blockAnimation[normalAttackCounter] : hitAnimation[normalAttackCounter]);

        normalAttackCounter = (normalAttackCounter == 3) ?  0 :  normalAttackCounter + 1 ;
    }

    void combo()
    {
        animator.SetTrigger(comboAttack[Random.Range(0, 2)]);
    }

    void elbowAttack()
    {
        animator.SetTrigger("elbowAttack");
        animator.SetTrigger((Random.Range(0, 5) == 1) ? "middleBlock" : "middleHit");
    }
}

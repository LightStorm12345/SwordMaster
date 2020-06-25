using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Animator animator;
    private bool AllowAttack;

    private void Start()
    {
        AllowAttack = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    private void Update()
    {
        // when left mouse button is pressed and the animation is complete then run the attack animation
        if (Input.GetKeyDown(KeyCode.Mouse0) && AllowAttack == true)
        {
            StartCoroutine(SwordAttack());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && AllowAttack == true)
        {
            StartCoroutine(SwordSpin());
        }
    }

    private IEnumerator SwordAttack()
    {
        // run the attack animation and wait for 0.8 seconds before allowing the user to use it again

        AllowAttack = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
        animator.SetBool("SwordAttack", true);
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("SwordAttack", false);
        gameObject.GetComponent<Collider2D>().enabled = false;
        AllowAttack = true;
    }
    private IEnumerator SwordSpin()
    {
        AllowAttack = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
        animator.SetBool("SwordSpin", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("SwordSpin", false);
        gameObject.GetComponent<Collider2D>().enabled = false;
        AllowAttack = true;
    }
}

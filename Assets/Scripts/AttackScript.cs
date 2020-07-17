using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Animator animator;
    private bool AllowAttack;
    public GameObject player;

    public bool isSword;
    public bool isSpear;

    private bool spearThrown;

    private void Start()
    {
        AllowAttack = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    private void Update()
    {
        if (isSword)
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

        if (isSpear)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && AllowAttack == true)
            {
                // become own object
                gameObject.transform.SetParent(null);
                animator.SetBool("Throw", true);
                AllowAttack = false;
            }
        }

        if (spearThrown) // from what I seen, this is the most efficient way to do it
        {
            ThrowSpear();
        }


    }

    public void AlertObserver(string message)
    {
        if (message.Equals("SpearAnimationComplete"))
        {
            animator.enabled = false;
            spearThrown = true;
        }
    }

    private void ThrowSpear()
    {
        float lerpSpeed = 1f;
        // dont ask why it's vector3 it wouldnt work on vector 2 for some reason
        Vector3 offset = new Vector3(0, 10, 0);
        Vector3 positionToMoveTo = gameObject.transform.localPosition + offset;

        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, positionToMoveTo, lerpSpeed * 5.0f * Time.deltaTime);

        /*if (gameObject.transform.position == positionToMoveTo)
        {
            Destroy(gameObject);
        }*/
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

        player.GetComponent<playerscript>().currSprite = 1;

        gameObject.GetComponent<Collider2D>().enabled = true;

        animator.SetBool("SwordSpin", true);

        yield return new WaitForSeconds(2f);

        animator.SetBool("SwordSpin", false);

        gameObject.GetComponent<Collider2D>().enabled = false;

        player.GetComponent<playerscript>().currSprite = 0;

        AllowAttack = true;
    }
}

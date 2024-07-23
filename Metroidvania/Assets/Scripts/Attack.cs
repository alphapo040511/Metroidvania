using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float dmgValue = 4;                          //데미지 값
    public GameObject throwableObject;                  //던질 수 있는 오브젝트
    public Transform attackCheck;

    private Rigidbody2D rigidbody2D;
    public Animator animator;                           //애니메이터 할당
    public bool canAttack = true;                       //공격 여부 체크
    public bool isTimeToCheck = false;

    public GameObject cam;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && canAttack)                //키보드 X를 누르고 공격할 수 있을때
        {
            canAttack = false;
            animator.SetBool("IsAttacking", true);
            StartCoroutine(AttackCooldown());
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f),
                Quaternion.identity);

            Vector2 direction = new Vector2(transform.localScale.x, 0);
            throwableObject.GetComponent<ThrowableWeapon>().direction = direction;              //인스턴스에서 생겨난 오브젝트에 방향성 할당
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.25f);
        canAttack = true;
    }
}

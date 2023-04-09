using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    Animator anim;

    float h;
    float v;

    bool isHmove;
    Vector3 direcVec;

    GameObject scanObject;
    public GameManager manager;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {

        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        bool hDo = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDo = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");


        if (hDo)
        {
            isHmove = true;
        }
        else if (vDo)
        {
            isHmove = false;
        }
        else if (hUp || vUp)
        {
            isHmove = h != 0;
        }


        if(anim.GetInteger("Hh") != h)
        {
            anim.SetInteger("Hh", (int)h);
            anim.SetBool("isChanged", true);
        }

        else if (anim.GetInteger("Vv") != v)
        {
            anim.SetInteger("Vv", (int)v);
            anim.SetBool("isChanged", true);
        }

        else 
            anim.SetBool("isChanged", false); 

        if(vDo && v == 1)
        {
            direcVec = Vector3.up;
        }
        else if (vDo && v == -1)
        {
            direcVec = Vector3.down;
        }
        else if (hDo && h == 1)
        {
            direcVec = Vector3.right;
        }
        else if (hDo && h == -1)
        {
            direcVec = Vector3.left;
        }

        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.WriteText(scanObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 MoveVec = isHmove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = MoveVec * Speed;

        Debug.DrawRay(rigid.position, direcVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, direcVec,  0.7f,LayerMask.GetMask("Object"));
        if (rayhit.collider != null)
        {
            scanObject = rayhit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}

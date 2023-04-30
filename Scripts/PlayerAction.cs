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
    //모바일 키
    int up_Value;
    int down_Value;
    int left_Value;
    int right_Value;

    bool up_Down;
    bool down_Down;
    bool left_Down;
    bool right_Down;

    bool up_Up;
    bool down_Up;
    bool left_Up;
    bool right_Up;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal") + right_Value + left_Value;
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical") + up_Value + down_Value;

        bool hDo = manager.isAction ? false : Input.GetButtonDown("Horizontal")||right_Down || left_Down; ;
        bool vDo = manager.isAction ? false : Input.GetButtonDown("Vertical") || up_Down || down_Down;
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal") || right_Up || left_Up;
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical") || up_Up || down_Up;



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

        up_Down = false;
        down_Down = false;
        left_Down = false;
        right_Down = false;

        up_Up = false;
        down_Up = false;
        left_Up = false;
        right_Up = false;
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
    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 1;
                up_Down = true;
                break;
            case "D":
                down_Value = -1;
                down_Down = true;
                break;
            case "L":
                left_Value = -1;
                left_Down = true;
                break;
            case "R":
                right_Value = 1;
                right_Down = true;
                break;
            case "A":
                if (scanObject != null)
                    manager.WriteText(scanObject);
                break;
            case "C":
                manager.SubMenuActive();
                break;
        }
    }
    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 0;
                up_Up = true;
                break;
            case "D":
                down_Value = 0;
                down_Up = true;
                break;
            case "L":
                left_Value = 0;
                left_Up = true;
                break;
            case "R":
                right_Value = 0;
                right_Up = true;
                break;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controler : MonoBehaviour {

    public float speed = 7f;
    public float jumpingSpeed = 7f;
    private float movement = 0f;
    public float jumpTime = 1f;
    public float underBombime = 4f;

    private Animator rabitAnim = null;
    private SpriteRenderer spriteRenderer;
    private Transform heroParent = null;
    private Rigidbody2D rabbit = null;

    private bool isGrounded = false;
    public bool facingRight = true;
    private bool initSize = true;
    private bool isDefenseless = true;
    
    bool JumpActive = false;
    float JumpTime = 0f;
    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;


    private float timerForBomb = 0;

    private Color bonusColor;
    private Color initColor;

    void Start()
    {
        rabbit = GetComponent<Rigidbody2D>();
        rabitAnim = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        LevelControler.current.setStartPosition(this.transform.position);
        this.heroParent = this.transform.parent;

        timerForBomb = underBombime;
        initColor = spriteRenderer.color;
        bonusColor = new Color(3f, 0.85f, 0.30f, 255f);
        
    }

    void Update()
    {
        if (!isDefenseless)
        {

            if ( timerForBomb> 0)
            {
                timerForBomb -= Time.deltaTime;
                spriteRenderer.color = bonusColor;
            }
            else
            {
                isDefenseless = true;
                timerForBomb = underBombime;
                spriteRenderer.color = initColor;
            }
        }
    }


    void FixedUpdate () {

        movement = Input.GetAxis("Horizontal");
        if (movement < 0)
            GetComponent<Rigidbody2D>().velocity = new Vector3(movement * speed,GetComponent<Rigidbody2D>().velocity.y);
        if (movement > 0)
            GetComponent<Rigidbody2D>().velocity = new Vector3(movement * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (movement < 0 && facingRight)
            Flip();
        if (movement > 0 && !facingRight)
            Flip();

        if (Mathf.Abs(movement) > 0)
        {
            rabitAnim.SetBool("run", true);
        }

        else
            rabitAnim.SetBool("run", false);

        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;

        int layer_id = 1 << LayerMask.NameToLayer("Ground");

        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
            if (hit.transform != null && hit.transform.GetComponent<MovingPlatform>() != null)
            {
                //Приліпаємо до платформи
                SetNewParent(this.transform, hit.transform);
            }
        }
        else
        {
            isGrounded = false;
            SetNewParent(this.transform, this.heroParent);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.JumpActive = true;
        }
        if (this.JumpActive)
        {
            //Якщо кнопку ще тримають
            if (Input.GetButton("Jump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = rabbit.velocity;
                    vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
                    rabbit.velocity = vel;
                }

            }
            else
            {
                this.JumpActive = false;
                this.JumpTime = 0;
            }
            
        }
        if (isGrounded)
        {
            rabitAnim.SetBool("jump", false);
        }
        else
        {
            rabitAnim.SetBool("jump", true);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }

    static void SetNewParent(Transform obj, Transform new_parent)
    {
        
            if (obj.transform.parent != new_parent)
            {
                //Засікаємо позицію у Глобальних координатах
                Vector3 pos = obj.transform.position;
                //Встановлюємо нового батька
                obj.transform.parent = new_parent;
                //Після зміни батька координати кролика зміняться
                //Оскільки вони тепер відносно іншого об’єкта
                //повертаємо кролика в ті самі глобальні координати
                obj.transform.position = pos;
            }
        }

    public void Enlarge(float n)
    {
        this.transform.localScale = new Vector3(n,n,n);
        initSize = false;
    }

    public void Inlarge(float n)
    {
        this.transform.localScale = new Vector3(n,n,n);
        initSize = true;
        isDefenseless = false;
    }

    public bool IsDefenseless {
        get {
            return isDefenseless;
        }
    }
    public bool HasDefaultSize {
        get {
            return initSize;
        }
    }


}

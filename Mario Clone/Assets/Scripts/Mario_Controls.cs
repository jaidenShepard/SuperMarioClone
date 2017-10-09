using UnityEngine;

public class Mario_Controls : MonoBehaviour {
    public float speed;
    private float xMin;
    private float xMax = 33.8f;
    private Rigidbody2D rb;

    bool facingRight = true;

    const float WALK_SPEED = 1;
    const float RUN_SPEED = 2;

    Animator anim;


    const int STATE_IDLE = 0;
    const int STATE_WALKING = 1;

    private string _currentDirection = "left";
    private int _currentAnimationState = STATE_IDLE;

    // Use this for initialization
    void Start() {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        speed = 1f;
        this.xMin = -0.255f;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //speed = Mathf.Clamp(speed + 0.25f, 0.0f, WALK_SPEED);
        anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        if (moveHorizontal > 0 && !facingRight)
        {
            flip();
        }else if (moveHorizontal < 0 && facingRight)
        {
            flip();
        }


        //transform.position += movement * speed;

        //transform.position = new Vector3(
        //    Mathf.Clamp(transform.position.x ,xMin, xMax),
        //    transform.position.y,
        //    transform.position.z
        //    );



    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float getXMin() {return this.xMin;}

    public void SetXMin(float newMin){ this.xMin = newMin; }
}

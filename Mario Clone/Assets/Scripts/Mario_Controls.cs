using UnityEngine;

public class Mario_Controls : MonoBehaviour {
    public float speed;

    private float xMin;
    private float xMax = 33.8f;
    private Rigidbody2D rb;

    private bool facingRight = true;

    const float WALK_SPEED = 1;
    const float RUN_SPEED = 2;

    Animator anim;

    void Start() {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        speed = 1.5f;
        this.xMin = -0.255f;
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        // speed = Mathf.Clamp(speed + 0.25f, 0.0f, WALK_SPEED);
        anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        rb.position = new Vector2
            (Mathf.Clamp(rb.position.x, xMin, xMax), 
             rb.position.y);

        if ((moveHorizontal > 0 && !facingRight) ||
            (moveHorizontal < 0 && facingRight)) {
            Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float getXMin() {return this.xMin;}

    public void SetXMin(float newMin){ this.xMin = newMin; }
}

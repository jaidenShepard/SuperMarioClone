using UnityEngine;

public class Camera_Scroll : MonoBehaviour {

    public GameObject mario;
    public float rightbound;

    void Start() {
        UpdatePlayerXMin();
    }

    // Update is called once per frame
    void LateUpdate () {
        if (mario.transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(
                Mathf.Min(mario.transform.position.x, rightbound),
                transform.position.y,
                transform.position.z
                );
            UpdatePlayerXMin();
        }
    }

    void UpdatePlayerXMin() {
        mario.GetComponent<Mario_Controls>().SetXMin(transform.position.x - Camera.main.rect.width + 1.64f);
    }
}

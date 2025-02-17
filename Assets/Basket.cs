using UnityEngine;
using UnityEngine.InputSystem;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    void Start () 
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update ()
    { 
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }

        if (collidedWith.CompareTag("Branch"))
        {
            Destroy(collidedWith);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            if (apScript != null)
            {
                apScript.RemoveAllBaskets();
            }
        }
    }
}

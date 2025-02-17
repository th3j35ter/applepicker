using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject branchPrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float changeDirChance = 0.1f;

    public float appleDropDelay = 1f;

    public int appleDropCount = 0;

    public float branchSpawnChance = 0.1f;

    public int branchesFallen = 0;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        appleDropCount += 1;
        RandomChances();
        Invoke("DropApple", appleDropDelay);
    }

    void DropBranch()
    {
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        branch.transform.position = transform.position;
        branchesFallen += 1;
        Invoke("DropBranch", appleDropDelay);
    }

    void RandomChances()
    {
        int randomNumber = Random.Range(0, 10);
        if (appleDropCount == randomNumber) 
        {
            DropBranch();
        }
    }
}

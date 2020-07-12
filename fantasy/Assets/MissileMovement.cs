using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    private static int EnemyCount = 0;

    public EnemyNameSetter nameSetter;

    public int HP;
    private int maxHP;
    [Range(0, 1)] public float hpLossMultiplier = 0.25f;
    [HideInInspector] public Transform player;
    public float speed = 2f;
    private float playerDistance;
    public float minDistance = 1f;

    private BoxCollider2D boxCollider;
    private LayerMask Sword;
    private Rigidbody2D rb2d;
    private fileIOManager iOManager;
    public Vector3 target_location;
    private bool target_found = false;
    private Vector3 target_direction; 

    private bool fileFound = false;

    void Awake()
    {
        EnemyCount++;
        // Debug.Log(enemyCount.ToString());
        iOManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<fileIOManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        maxHP = HP;

        nameSetter = transform.GetComponentInParent<EnemyNameSetter>();
        transform.name = nameSetter.getNameForObject();
        createEnemyFile();

    }

    // Gets called from instantiation
    public void createEnemyFile()
    {
        iOManager.CreateFileFromStringNoDuplicates(transform.name);
        fileFound = true;
    }

    // Update is called once per frame
    void Update()
    {

        //simply move towards player,  like a ghost maybe
        float rot_z = Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        playerDistance = Vector2.Distance(transform.position, player.position);



        if (!target_found)
        {
            target_location = player.position;
            target_found = true;
        }

        rb2d.MovePosition(Vector2.MoveTowards(transform.position, target_location, speed * Time.deltaTime));



        // Check if the file of this enemy exists. If it doesnt, decrease the enmy health by a ton
        if (fileFound)
        {
            if (!iOManager.isFileExists(transform.name))
            {
                fileFound = false;
                HP = (int)(maxHP * hpLossMultiplier);
            }
        }
    }

    public void TakeDamage()
    {
        HP--;

        if (HP <= 0)
        {
            die();
        }
    }

    public void die()
    {
        // maybe stuff
        EnemyCount--;
        if (iOManager.isFileExists(transform.name))
            iOManager.DeleteFile(transform.name);
        Destroy(this.gameObject);
    }

    public int enemyCount
    {
        get { return EnemyCount; }
    }
}



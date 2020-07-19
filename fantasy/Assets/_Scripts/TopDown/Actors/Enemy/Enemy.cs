using UnityEngine;

public class Enemy : MonoBehaviour
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
    public float angle;
    public AudioClip enemyGotHit;

    private BoxCollider2D boxCollider;
    private LayerMask Sword;
    private Rigidbody2D rb2d;
    private fileIOManager iOManager;
    private AudioSource audioSource;
    private Animator anim;


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
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

        maxHP = HP;


        nameSetter = transform.GetComponentInParent<EnemyNameSetter>();
        transform.name = nameSetter.getNameForObject();

        
        createEnemyFile();

        Debug.Log(transform.name + "'s starting HP: " + HP);
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
        // rot_z = (Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg) - 90;
        // transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        // playerDistance = Vector2.Distance(transform.position, player.position);
        rb2d.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));

        angle = AngleTo(transform.position, player.position);
        if ((angle >= 0 && angle < 45) || (angle > 315 && angle <= 359))
        {
            anim.SetFloat("Horizontal", 1);
            anim.SetFloat("Vertical", 0);
            //Debug.Log("Facing right");
        }
        else if(angle >= 135 && angle < 225)
        {
            anim.SetFloat("Horizontal", -1);
            anim.SetFloat("Vertical", 0);
            //Debug.Log("facing Left");
        }
        else if(angle >= 45 && angle < 135)
        {
            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", 1);
            //Debug.Log("Facing Up");
        }
        else if(angle >= 225 && angle < 315)
        {
            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", -1);
            //Debug.Log("facing down");
        }


        // Check if the file of this enemy exists. If it doesnt, decrease the enmy health by a ton
        if(iOManager.isActive && fileFound)
        {
            Debug.Log(iOManager.isFileExists(transform.name));
            if (!iOManager.isFileExists(transform.name))
            {
                Debug.Log(transform.name + "'s file has been deleted!");
                fileFound = false;
                HP = (int)(maxHP * hpLossMultiplier);
            }
        }
    }

     public float FindDegree(int x, int y)
     {
        float value = (float)((Mathf.Atan2(x, y) / Mathf.PI) * 180f);
        if(value < 0) value += 360f;
    
        return value;
    }
    
    public float AngleTo(Vector2 this_, Vector2 to)
    {
        Vector2 direction = to - this_;
        float angle = Mathf.Atan2(direction.y,  direction.x) * Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;
        return angle;
    }

    public void TakeDamage()
    {
        HP--;
        Debug.Log(transform.name + "HP: " + HP);
        audioSource.PlayOneShot(enemyGotHit);

        if(HP <= 0)
        {
            die();
        }
    }

    public void die() {
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



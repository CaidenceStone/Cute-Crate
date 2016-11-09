using UnityEngine;

public class BoxOpening : MonoBehaviour
{
    public GameObject boxOpen;
    public GameObject cutie;
    private JumpUp jumpUp;
    public GameObject soundPlayer;
    public int[] tierWeights;
    public string cutieFilePath;
    public bool randomizeCutie;
    public int rarityTier;
    public int[] numberOfImagesByTier = {18, 8, 6};
    private int highestTier;
    private SpriteRenderer cutieRenderer;
    private AudioSource revealSound;

    void Start()
    {
        highestTier = tierWeights.Length - 1;
        if (null == boxOpen)
        {
            Debug.LogError("BoxOpen game object not attached to BoxOpening!");
        }
        if (null == cutie)
        {
            Debug.LogError("Cutie game object not attached to BoxOpening!");
        }
        else
        {
            cutieRenderer = cutie.GetComponent<SpriteRenderer>();
            if (null == cutieRenderer)
            {
                Debug.LogError("BoxOpening could not find SpriteRenderer on Cutie object!");
            }
            jumpUp = cutie.GetComponent<JumpUp>();
            if (null == jumpUp)
            {
                Debug.LogError("BoxOpening could not find JumpUp on Cutie object!");
            }
        }
        if (null == soundPlayer)
        {
            Debug.LogError("Sound Player game object not attached to BoxOpening!");
        }
        else
        {
            revealSound = soundPlayer.GetComponent<AudioSource>();
            if (null == revealSound)
            {
                Debug.LogError("Closed box could not find AudioSource on Sound Player object!");
            }
        }
    }

    void OnMouseDown()
    {
        // Hide closed box, show open box
        gameObject.SetActive(false);
        boxOpen.SetActive(true);

        // Pick which cutie is active
        //rarityTier = 0;
        if (randomizeCutie)
        {
            rarityTier = PickRandomTier();
            cutieFilePath = getRandomCutiePath(rarityTier);
        }
        string soundPath = getRevealSoundPath(rarityTier);

        cutieRenderer.sprite = Resources.Load(cutieFilePath, typeof(Sprite)) as Sprite;
        AudioClip clip = Resources.Load(soundPath, typeof(AudioClip)) as AudioClip;
        revealSound.PlayOneShot(clip);

        // Make cutie visible, play sound, and start animation
        cutie.SetActive(true);
        revealSound.Play();
        jumpUp.Animate();
    }

    int PickRandomTier()
    {
        int dieRoll = Random.Range(0, 100);

        rarityTier = 0;
        for (int currentTier = highestTier; currentTier > 0; currentTier--)
        {
            if (dieRoll < tierWeights[currentTier])
            {
                rarityTier = currentTier;
                break;
            }
        }

        return rarityTier;
    }

    string getRevealSoundPath(int rarityTier)
    {
        return "Reveal Sounds/" + rarityTier.ToString();
    }

    string getRandomCutiePath(int rarityTier)
    {
        string cutieFilePath = "";
        cutieFilePath += "Cutie Sprites/Tier";
        //pick rarity tier

        cutieFilePath += rarityTier + "/";
        
        //if (Directory.Exists(Application.dataPath + "/Resources/" + cutieFilePath))
        //{
        //    var info = new DirectoryInfo(Application.dataPath + "/Resources/" + cutieFilePath);
        //    if (null != info)
        //    {
        //        numberOfImages = info.GetFiles().Length/2; // the other half are meta files
        //        Debug.Log("Number of images in folder!... " + numberOfImages.ToString());
        //    }
        //}
        int cutieNumber = Random.Range(0, numberOfImagesByTier[rarityTier]);
        cutieFilePath += cutieNumber.ToString();
        return cutieFilePath;
    }
}

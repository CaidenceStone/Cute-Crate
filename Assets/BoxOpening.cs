using UnityEngine;
using System.Collections;
using System.IO;

public class BoxOpening : MonoBehaviour {

    public GameObject boxOpen;
    public GameObject cutie;
    public GameObject soundPlayer;
    public float[] tierWeights;
    public string cutieFilePath;
    public bool randomizeCutie;
    private int highestTier;
    private SpriteRenderer cutieRenderer;
    private AudioSource revealSound;

    // Use this for initialization
    void Start()
    {
        highestTier = tierWeights.Length-1;
        if (null == boxOpen)
        {
            Debug.LogError("BoxOpen game object not attached to BoxClosed!");
        }
        if (null == cutie)
        {
            Debug.LogError("Cutie game object not attached to BoxClosed!");
        }
        else
        {
            cutieRenderer = cutie.GetComponent<SpriteRenderer>();
            if (null == cutieRenderer)
            {
                Debug.LogError("Closed Box could not find SpriteRenderer on Cutie object!");
            }
        }
        if (null == soundPlayer)
        {
            Debug.LogError("Sound Player game object not attached to BoxClosed!");
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
        int rarityTier = 0;
        if (randomizeCutie)
        {
            rarityTier = PickRandomTier();
            cutieFilePath = getRandomCutiePath(rarityTier);
        }
        string soundPath = getRevealSoundPath(rarityTier);

        cutieRenderer.sprite = Resources.Load(cutieFilePath, typeof(Sprite)) as Sprite;
        revealSound.clip = Resources.Load(soundPath, typeof(AudioClip)) as AudioClip;

        // Make cutie visible and play sound
        cutie.SetActive(true);
        revealSound.Play();
    }

	// Update is called once per frame
	void Update () {
	
	}

    int PickRandomTier()
    {
        float dieRoll = Random.Range(0, 1);

        int rarityTier = 0;
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

    string getRevealSoundPath( int rarityTier)
    {
        return "Reveal Sounds/" + rarityTier.ToString();
    }

    string getRandomCutiePath( int rarityTier)
    {
        string cutieFilePath = "";
        cutieFilePath += "Cutie Sprites/Tier";
        //pick rarity tier
        
        cutieFilePath += rarityTier.ToString();

        int numberOfImages = 0;
        if (Directory.Exists(Application.dataPath + "/Resources/" + cutieFilePath))
        {
            var info = new DirectoryInfo(Application.dataPath + "/Resources/" + cutieFilePath);
            if (null != info)
            {
                numberOfImages = info.GetFiles().Length;
            }
        }
        int cutieNumber = Random.Range(0, numberOfImages);
        cutieFilePath += cutieNumber.ToString();
        return cutieFilePath;
    }

}

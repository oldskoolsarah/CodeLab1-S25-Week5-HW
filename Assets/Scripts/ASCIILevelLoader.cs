using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{

    public GameObject prefabPlayer;
    public GameObject prefabWall;
    public GameObject prefabObstacle;
    public GameObject prefabGoal;

    string filePath;

    public string fileName;
    public int currentLevel = 0;  
    
    public int CurrentLevel
    {
        set
        {
            currentLevel = value;
            LoadLevel();
        }
        get { 
            return currentLevel;
        }
    }

    public float offsetX = -5;
    public float offsetY = 5;

    GameObject levelHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        if (levelHolder == null)
        {
            Destroy(levelHolder);
            
        }

        levelHolder = new GameObject(name: "Level Holder");

        filePath = Application.dataPath;

        //string fileContents = File.ReadAllText(path: filePath + fileName);
        //Debug.Log(fileContents);

        string[] lines = File.ReadAllLines(path:filePath + fileName.Replace("num",currentLevel.ToString()));

        //looping through each row of the file
        for (int y = 0; y < lines.Length; y++)
        {
            Debug.Log(lines[y]);

            string line = lines[y]; // obtain string for the line
            char[] charArray = line.ToCharArray(); // convert string to char array

            //looping through each character of the row
            for (int x = 0; x < charArray.Length; x++)
            {

                char c = charArray[x]; // obtain character at position x

                GameObject newObj = null;

                switch (c)
                {
                    case 'P':
                        newObj = Instantiate<GameObject>(prefabPlayer);
                        break;
                    case 'W':
                        newObj = Instantiate<GameObject>(prefabWall);
                        break;
                    case '*':
                        newObj = Instantiate<GameObject>(prefabObstacle);
                        break;
                    case 'G':
                        newObj = Instantiate<GameObject>(prefabGoal);
                        break;
                    default:
                        break;
                }

                if (newObj != null)
                {
                    newObj.transform.parent = levelHolder.transform;
                    newObj.transform.position = new Vector3(x + offsetX, -y + offsetY, 0);
                }

                /*
                if (c == 'P')
                {
                   newObj = Instantiate<GameObject>(prefabPlayer);

                   newObj.transform.position = new Vector3(x + offsetX, -y + offsetY, 0);

                }

                if (c == 'W')
                {
                    newObj = Instantiate<GameObject>(prefabWall);

                    newObj.transform.position = new Vector3(x + offsetX, -y + offsetY, 0);

                }
                */


            }


        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEditor;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    // for maze prefab (parent object)
    public Maze mazePrefab;
    // to be able to hold created instance
    private Maze mazeInstance;
    
    public static GameManager gmInstance;
    public GameObject saveCanvas;

    public bool prefabSaved;
    public int mazeNumber = 0;
    
    //private RoomWall roomWall;
    //private bool spawnroom;
    /*public Room roomPrefab;
    private Room roomInstance;
    public Text gameTimer;
    public GameObject player;
    public GameTimer gT;
    */
    
    void Start()
    {
        BeginGame();
        
    }

    private void Update()
    {
        // spawn the player at starting cell and set the timer when maze is finished
        
        if (mazeInstance.roomHolderObject.GetComponent<Room>().canOpenCanvas)
        {
            saveCanvas.SetActive(true);
            
        }
        
    }

    public void BeginGame()
    {
        
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
        /*roomInstance = Instantiate(roomPrefab, mazeInstance.transform) as Room;
        player = Instantiate(player, mazeInstance.startingCell.transform.position, Quaternion.identity);
        player.SetActive(false);
        */
    }


    public void CreateButton()
    {
        prefabSaved = false;
        saveCanvas.SetActive(false);
        Destroy(FindObjectOfType<Maze>().gameObject);
        Debug.Break();
        BeginGame();
    }
    

    public void SaveMaze()
    {
        if (!prefabSaved)
        {
            mazeNumber++;
            string localPath = "Assets/Prefabs/" + "Maze" +mazeNumber.ToString()+ ".prefab";
            // Make sure the file name is unique, in case an existing Prefab has the same name
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            PrefabUtility.SaveAsPrefabAssetAndConnect(mazeInstance.gameObject, localPath, InteractionMode.UserAction);
            prefabSaved = true;
            
        }
        
        
    }
    

    
    
}

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    // for maze prefab (parent object)
    public Maze mazePrefab;
    // to be able to hold created instance
    private Maze mazeInstance;   
    
    public Room roomPrefab;
    private Room roomInstance;

    private RoomWall roomWall;
    public GameObject player;
    private bool spawnroom;
    public Text gameTimer;

    public GameObject saveCanvas;
    //public GameTimer gT;

    
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
        Destroy(FindObjectOfType<Maze>().gameObject);
        BeginGame();
    }
    

    public void SaveMaze()
    {
        string localPath = "Assets/Prefabs/" + mazeInstance.gameObject.name + ".prefab";
        
        // Make sure the file name is unique, in case an existing Prefab has the same name
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(mazeInstance.gameObject, localPath, InteractionMode.UserAction);
    }
    

    
    
}

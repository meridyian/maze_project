using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Maze : MonoBehaviour
{
    // instantiate maze elements
    public IntVector2 size;
    public MazeCell cellPrefab;
    public MazeCellWall wallPrefab;
    
    // instantiate room elements
    public float generationStepDelay;
    public List<Vector3> deadEndList;
    public GameObject roomHolderObject;
    //public Room roomHolder;
    
    // instantiate ceiling to form minimap
    public CeilingCell ceilingPrefab;
    public GameObject ceilingHolder;

    //to keep things tidy
    public GameObject mazeCellHolder;
    
    // keep the starting cell of DFS
    public MazeCell startingCell;
    public bool isFinished;
    private MazeCell[,] cells;
    

    
    

    public void Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);   
        cells = new MazeCell[size.x, size.z];
        
        // Generate base, walls and ceiling maze cells 
        
        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.z; z++)
            {
                CreateCell(x, z); 
                CreateCeilingCell(x, z);

            }
        }

        // start depth-first-search algorithm to build the maze by selecting the walls that will be used
        StartCoroutine(DFS());
        
    }

    public void CreateCell(int x, int z)
    {
        deadEndList = new List<Vector3>();
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        newCell.Initialize(x,z,mazeCellHolder.transform);
        cells[x,z] = newCell;
        newCell.transform.localPosition = new Vector3(x - size.x * 0.5f + 0.5f, 0f, z - size.z * 0.5f + 0.5f);
        
        
        // if x ==0 or z == 0, the outer cells will be created as west and south
        
        if (x == 0)
        {
            newCell.West = Instantiate(wallPrefab) as MazeCellWall;
            newCell.West.name = "West " + wallPrefab.name;
            newCell.West.transform.parent = newCell.transform;
            
            newCell.West.transform.localPosition = new Vector3(-0.5f, 0.5f, 0f);
        }
        else
        {
            // if x != 0 east wall of the cell on the left will be west wall of the newcell
            newCell.West = cells[x - 1, z].East;
        }
        if (z == 0)
        {
            newCell.South = Instantiate(wallPrefab) as MazeCellWall;
            newCell.South.name = "South " + wallPrefab.name;
            newCell.South.transform.parent = newCell.transform;
            newCell.South.transform.localPosition = new Vector3(0f, 0.5f, -0.5f);
        }
        else
        {
            // if z != 0 north wall of the down cell  will be south wall of the newcell
            newCell.South = cells[x, z-1].North;
        }

        newCell.North = Instantiate(wallPrefab) as MazeCellWall;
        newCell.North.name = "North " + wallPrefab.name;
        newCell.North.transform.parent = newCell.transform;
        newCell.North.transform.localPosition = new Vector3(0f, 0.5f, 0.5f);
        
        newCell.East = Instantiate(wallPrefab) as MazeCellWall;
        newCell.East.name = "East " + wallPrefab.name;
        newCell.East.transform.parent = newCell.transform;
        newCell.East.transform.localPosition = new Vector3(0.5f, 0.5f, 0f);
    }

    
    
    
    public IEnumerator DFS()
    {
        // uses stack since it works with LIFO 
        // your last cell of the active path will be the first cell after reaching the dead end
        
        Stack<MazeCell> cellsStack = new Stack<MazeCell>();

        // start from a random cell, add randomization
       
        int startingRandx = Random.Range(0, size.x);
        int startingRandz = Random.Range(0, size.z);
        
        MazeCell currentCell = cells[startingRandx,startingRandz];
        // keep the starting cell to spawn player
        startingCell = cells[startingRandx,startingRandz];
        
        currentCell.Visited = true;
        cellsStack.Push(currentCell);

        while (cellsStack.Count > 0)
        {
            WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
            yield return delay;

            // select a random neighbouring cell
            List<MazeCell> neighbours = getUnvisitedNeighbours(currentCell);

            // dead-end
            if (neighbours.Count == 0)
            {
                // to check if you can see the deadends
                deadEndList.Add(currentCell.transform.localPosition);
                currentCell = cellsStack.Pop();
                continue;
            }
            
            // take a random cell from neighbours list to visit as nextCell
            // in the room case you cannot take a random cell, you have to be specifying the cells
            // that you have no walls between 

            MazeCell nextCell = neighbours[Random.Range(0, neighbours.Count)];
            nextCell.gameObject.GetComponentInChildren<Renderer>().material.color = Color.gray;
            
            
            if (currentCell.position.x == nextCell.position.x)
            {
                if (currentCell.position.z < nextCell.position.z)
                    currentCell.North.gameObject.SetActive(false);
                else
                    currentCell.South.gameObject.SetActive(false);

            }

            if (currentCell.position.z == nextCell.position.z)
            {
                if (currentCell.position.x < nextCell.position.x)
                    currentCell.East.gameObject.SetActive(false);
                else
                    currentCell.West.gameObject.SetActive(false);

            }

            nextCell.Visited = true;

            cellsStack.Push(currentCell);
            currentCell = nextCell;
            
            

        }
        
        Debug.Log("DFS is finished");
        
        StartCoroutine(roomHolderObject.GetComponent<Room>().SpawnRoom());
        yield return new WaitForSeconds(2f);
        isFinished = true;


    }

    
    
    private List<MazeCell> getUnvisitedNeighbours(MazeCell cell)
    {
        List<MazeCell> cellsList = new List<MazeCell>();

        int x = cell.position.x;
        int z = cell.position.z;

        // south
        if ((z > 0) && !cells[x, z - 1].Visited)
        {
            cellsList.Add(cells[x, z-1]);
        }
        // west
        if ((x > 0) && !cells[x-1, z].Visited)
        {
            cellsList.Add(cells[x-1, z]);
        }
        // east
        if ((x < size.x-1) && !cells[x+1, z].Visited)
        {
            cellsList.Add(cells[x+1, z]);
        }
        // north
        if ((z < size.z - 1) && !cells[x, z + 1].Visited)
        {
            cellsList.Add(cells[x, z+1]);
        }

        return cellsList;

    }

    public void CreateCeilingCell(int x , int z)
    {
        CeilingCell newceilingCell = Instantiate(ceilingPrefab) as CeilingCell;
        newceilingCell.Initialize(x,z,ceilingHolder.transform);
        newceilingCell.transform.localPosition = new Vector3(x - size.x * 0.5f + 0.5f, 2f, z - size.z * 0.5f + 0.5f);

    }
    
    
    

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Maze : MonoBehaviour
{
    
    public IntVector2 size;
    public MazeCell cellPrefab;
    public MazeCellWall wallPrefab;
    public float generationStepDelay;
    
    private MazeCell[,] cells;

    
    void Start () {
        Debug.Log("Maze.Start()");
    }
	
    void Update () {
		
    }
    

    public void Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);   
        cells = new MazeCell[size.x, size.z];
        

        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.z; z++)
            {
                CreateCell(x, z);
                
            }
        }

        StartCoroutine(DFS());
        
    }

    public void CreateCell(int x, int z)
    {
        
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        newCell.Initialize(x,z,transform);
        cells[x,z] = newCell;
        newCell.transform.localPosition = new Vector3(x - size.x * 0.5f + 0.5f, 0f, z - size.z * 0.5f + 0.5f);
        
        
        if (x == 0)
        {
            newCell.West = Instantiate(wallPrefab) as MazeCellWall;
            newCell.West.transform.parent = newCell.transform.parent;
            newCell.West.transform.localPosition = newCell.transform.localPosition + new Vector3(-0.5f, 0f, 0f);
        }
        else
        {
            newCell.West = cells[x - 1, z].East;
        }
        if (z == 0)
        {
            newCell.South = Instantiate(wallPrefab) as MazeCellWall;
            newCell.South.transform.parent = newCell.transform.parent;
            newCell.South.transform.localPosition = newCell.transform.localPosition + new Vector3(0f, 0f, -0.5f);
        }
        else
        {
            newCell.South = cells[x, z-1].North;
        }
        newCell.North = Instantiate(wallPrefab) as MazeCellWall;
        newCell.North.transform.parent = newCell.transform.parent;
        newCell.North.transform.localPosition = newCell.transform.localPosition + new Vector3(0f, 0f, 0.5f);
        
        newCell.East = Instantiate(wallPrefab) as MazeCellWall;
        newCell.East.transform.parent = newCell.transform.parent;
        newCell.East.transform.localPosition = newCell.transform.localPosition + new Vector3(0.5f, 0f, 0f);
    }

    public IEnumerator DFS()
    {
        // generate it using Stack
        Stack<MazeCell> cellsStack = new Stack<MazeCell>();

        // start from a random cell, add randomization
        MazeCell currentCell = cells[0, 0];
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
                currentCell = cellsStack.Pop();
                continue;
            }

            MazeCell nextCell = neighbours[Random.Range(0, neighbours.Count)];
            nextCell.gameObject.GetComponentInChildren<Renderer>().material.color = Color.gray;

            if (currentCell.position.x == nextCell.position.x)
            {
                if (currentCell.position.z < nextCell.position.z)
                    currentCell.North.Visible = false;
                else
                    currentCell.South.Visible = false;

            }

            if (currentCell.position.z == nextCell.position.z)
            {
                if (currentCell.position.x < nextCell.position.x)
                    currentCell.East.Visible = false;
                else
                    currentCell.West.Visible = false;

            }

            nextCell.Visited = true;

            cellsStack.Push(currentCell);
            currentCell = nextCell;

        }
    }

    public void TestDFS()
    {
        for(int x = 0; x<size.x; x++)
        {
            for(int z =0; z<size.z; z++) {
                Debug.Log("Cell[" + x + "," + z + "]: " + getUnvisitedNeighbours(cells[x, z]).Count);
            }
        }

        cells[2, 2].North.Visible = false;
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


        
       



    
    
}

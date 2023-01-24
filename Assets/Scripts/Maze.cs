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
    public float generationStepDelay;
    public IntVector2 size;
    public MazeCell cellPrefab;
    private MazeCell[,] cells;
    public GameObject wallPrefab;
    



    public IEnumerator Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);   
        cells = new MazeCell[size.x, size.z];
        

        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.z; z++)
            {
                yield return delay;
                CreateCell(new IntVector2(x, z));
                
                
            }
        }
        
        
        
       
    }

    public void CreateCell(IntVector2 coordinates)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.coordinates = coordinates;

        newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        newCell.transform.parent = transform;
        // store localPosition values for room 
        newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
        Debug.Log(newCell.transform.localPosition.x);
        Debug.Log(newCell.transform.localPosition.z);
        // 
        
    }


        
       



    
    
}

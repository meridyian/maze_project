using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IDataPersistence
{
    
    // since only reads
    void LoadData(GameData data);

    // allow implementing string to modify the data
    void SaveData(ref GameData data);
}
